// GantryMove_test.cpp : 定義主控台應用程式的進入點。
//

#include "stdafx.h"

#define	MAX_AXIS	4
#define	CHECK(ret)	if(NO_ERR != (ret)) \
	{ \
		_tprintf(_T("error code = %d\n"), ret); \
		throw std::exception(); \
	}

enum
{
	INIT	= 1
	,
	HOME
	,
	HOME_1
	,
	RUN
	,
	RUN_1
	,
	RUN_2
	,
	RUN_3
	,
	RUN_4
	,
	RESET_UNIT
	,
	PAUSE
	,
	GANTRY_HOME
	,
	GANTRY_HOME_1
	,
	FINAL
};

int _tmain(int argc, _TCHAR* argv[])
{
	bool	error = false;
	bool	dispPos = false;
	char	c;
	short	seq[32] = {0};
	short	top		= 0;
	int		boardId = 0;
	long	lpos, rpos;
	long	status;

	_tprintf(_T("Open card ... "));
	if(!MCT81XX_Open(boardId))
	{
		_tprintf(_T("Error!\n"));
		return -1;
	}
	_tprintf(_T("OK.\n"));
	seq[top=0] = INIT;
	while(seq[top])
	{
		Sleep(1);
		if(_kbhit())
		{
			c = getch();
			if(TCHAR('q')==c)
			{
				break;
			}
			else
			{
				if(PAUSE == seq[top])
				{
					--top;
				}
			}
		}
		if(dispPos)
		{
			for(int i=0; MAX_AXIS>i; ++i)
			{
				MCT81XX_GetLogicPos(boardId, 1+i, &lpos);
				MCT81XX_GetRealPos(boardId, 1+i, &rpos);
				_tprintf(_T("#%d %ld, %ld, "), 1+i, lpos, rpos);
			}
			_puttc(TCHAR('\n'), stdout);
		}
		switch(seq[top])
		{
		case	RESET_UNIT:
			if(AXIS_BUSY == MCT81XX_GetDriveEnd(boardId, 1))
			{
				break;
			}
			CHECK( MCT81XX_GetAxisStatus(boardId, 1, &status) );
			if(0x300 & status)
			{
				_tprintf(_T("#1 Limit Error!\n"));
				seq[++top] = PAUSE;
				break;
			}
			CHECK( MCT81XX_ResetUnit(boardId, 1) );
			CHECK( MCT81XX_ResetUnit(boardId, 2) );
			if(AXIS_BUSY == MCT81XX_GetDriveEnd(boardId, 2))
			{
				break;
			}
			CHECK( MCT81XX_GetAxisStatus(boardId, 2, &status) );
			if(0x300 & status)
			{
				_tprintf(_T("#1 Limit Error!\n"));
				seq[++top] = PAUSE;
				break;
			}
			--top;
			break;
		case	INIT:
			_tprintf(_T("Servo On ... "));
			for(int i=0; MAX_AXIS>i; ++i)
			{
				CHECK( MCT81XX_SetSpeed(boardId, 1+i, 100, 10000, 20000, 20000, 0) );
			}
			for(int i=0; MAX_AXIS>i; ++i)
			{
				CHECK( MCT81XX_ResetUnit(boardId, 1+i) );
			}
			for(int i=0; MAX_AXIS>i; ++i)
			{
				CHECK( MCT81XX_ServoOn(boardId, 1+i) );
			}
			Sleep(3000);
			_tprintf(_T("OK.\n"));
			seq[top] = HOME;
			break;
		case	HOME:
			dispPos = true;
			_tprintf(_T("Homing ... "));
			CHECK( MCT81XX_SetHomingSpeed(boardId, 1, 1000, 10000, 20000, 0) );
			CHECK( MCT81XX_SetHomingSpeed(boardId, 2, 1000, 10000, 20000, 10000) );
			CHECK( MCT81XX_SetHomingSpeed(boardId, 3, 1000, 10000, 20000, 0) );
			CHECK( MCT81XX_SetHomingSpeed(boardId, 4, 1000, 10000, 20000, 0) );
			for(int i=0; MAX_AXIS>i; ++i)
			{
				CHECK( MCT81XX_Homing(boardId, 1+i, 35) );
			}
			seq[top] = HOME_1;
			break;
		case	HOME_1:
			error = false;
			for(int i=0; MAX_AXIS>i; ++i)
			{
				if(HOMING_NOW == MCT81XX_GetHomingStatus(boardId, 1+i))
				{
					error = true;
					break;
				}
			}
			if(error)
			{
				break;
			}
			_tprintf(_T("OK.\n"));
			seq[top] = RUN;
			break;
		case	RUN:
			_tprintf(_T("Gantry_Init ... "));
			CHECK( MCT81XX_Gantry_Init(boardId, 2, 1, 0, 1, 1, 10000, 1000) );	// Gain = 10/1000 = 0.01, offset is abs
			seq[top] = RUN_1;
			break;
		case	RUN_1:
			if(AXIS_BUSY == MCT81XX_GetDriveEnd(boardId, 1))
			{
				break;
			}
			if(AXIS_BUSY == MCT81XX_GetDriveEnd(boardId, 2))
			{
				break;
			}
			_tprintf(_T("OK.\n"));
//			seq[top] = RUN_2;
			seq[top] = GANTRY_HOME;
			break;
		case	GANTRY_HOME:
			CHECK( MCT81XX_Gantry_SetHomeSpeed(boardId, /*MasterUnitNo=*/1, /*HomeSpeed1=*/1000, /*HomeSpeed2=*/100, /*HomeAcc=*/2000, /*HomeOffset=*/0) );
			CHECK( MCT81XX_Gantry_HomeMove(boardId, 2, 1, 80) );
			seq[top] = GANTRY_HOME_1;
			break;
		case	GANTRY_HOME_1:
			if(AXIS_BUSY == MCT81XX_GetDriveEnd(boardId, 1))
			{
				break;
			}
			seq[top] = FINAL;
			break;
		case	RUN_2:
			seq[top] = RUN_3;
			seq[++top] = RESET_UNIT;
			break;
		case	RUN_3:
			CHECK( MCT81XX_Gantry_AbsMove(boardId, 2, 1, 2000) );
			seq[top] = RUN_4;
			seq[++top] = RESET_UNIT;
			break;
		case	RUN_4:
			CHECK( MCT81XX_Gantry_AbsMove(boardId, 2, 1, -2000) );
			seq[top] = RUN_2;
			break;
		case	FINAL:
			_tprintf(_T("Press any key to continue ...\n"));
			getch();
			seq[top] = 0;
			break;
		}
	}
	MCT81XX_Close(boardId);
	return 0;
}

