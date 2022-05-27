using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Aurotek
{
    public class MCT81XX
    {
        public class Exception : System.Exception
        {
            public Exception(short errCode)
            {
                this.errCode = errCode;
            }
            private short errCode;
        }
        private static short Check(short ret)
        {
            if (NO_ERR != ret)
            {
                if (!disableException)
                {
                    throw new Exception(ret);
                }
            }
            return ret;
        }
        public static short PP_RUNNING = 2;
        public static short HOMING_NOW = 1;
        public static short HOMING_FINISH = 0;
        public static short NO_ERR = 0;
        public static short LINK_ERR = -1;
        public static short CARD_OPEN_ERR = -2;
        public static short UNIT_NO_ERR = -3;
        public static short PARA_WR_ERR = -4;
        public static short PARAMETER_ERR = -5;
        public static short AXIS_BUSY = -6;
        public static short LINE_AXIS_ERR = -7;
        public static short HOMING_ERR = -8;
        public static short CIR_CENTER_ERR = -9;
        public static short MODULE_ERR = -10;
        public static short FOLLOW_ERR = -11;
        public static short SYNC_AXIS_ERR = -12;
        public static short AXIS_ERR = -13;
        public static short CARD_NO_ERR = -14;
        public static short DATA_ERR = -51;
        public static short TotalUnit_ERR = -52;
        public static short MODULE_NO_ERR = -54;
        public static short UNIT_CNT_ERR = -55;
        public static short PARA_RD_ERR = -56;
        public static short PARA_WR_BUSY = -57;
        public static short LOG_RUNNING = -58;
        public static short MULTI_AXIS_BUSY = -59;
        public static short MULTI_AXIS_ERR = -60;
        public static short INTERNAL_ERR_0 = -200;
        public static short INTERNAL_ERR_1 = -201;
        public static short INTERNAL_ERR_2 = -202;
        public static short INTERNAL_ERR_3 = -203;
        public static short INTERNAL_ERR_4 = -204;
        public static short INTERNAL_ERR_5 = -205;
        public static short INTERNAL_ERR_6 = -206;
        public static short INTERNAL_ERR_7 = -207;
        public static short INTERNAL_ERR_8 = -208;
        public static short INTERNAL_ERR_9 = -209;
        public static short INTERNAL_ERR_10 = -210;
        public static short INTERNAL_ERR_11 = -211;
        public static short INTERNAL_ERR_12 = -212;
        public static short INTERNAL_ERR_13 = -213;
        public static short INTERNAL_ERR_14 = -214;
        public static short INTERNAL_ERR_15 = -215;
        public static short INTERNAL_ERR_16 = -216;
        public static short INTERNAL_ERR_17 = -217;
        public static short INTERNAL_ERR_18 = -218;
        public static short INTERNAL_ERR_19 = -219;
        public static short INTERNAL_ERR_20 = -220;
        public static short INTERNAL_ERR_21 = -221;
        public static short INTERNAL_ERR_22 = -222;
        public static short INTERNAL_ERR_23 = -223;
        public static short INTERNAL_ERR_24 = -224;
        public static short INTERNAL_ERR_25 = -225;
        public static short INTERNAL_ERR_26 = -226;
        public static short INTERNAL_ERR_27 = -227;
        public static short INTERNAL_ERR_28 = -228;
        public static short INTERNAL_ERR_29 = -229;
        public static short INTERNAL_ERR_30 = -230;
        public static short INTERNAL_ERR_31 = -231;
        public static short INTERNAL_ERR_32 = -232;
        public static short INTERNAL_ERR_33 = -233;
        public static short INTERNAL_ERR_34 = -234;
        public static short INTERNAL_ERR_35 = -235;
        public static short INTERNAL_ERR_36 = -236;
        public static short INTERNAL_ERR_98 = -298;
        public static short INTERNAL_ERR_99 = -299;
        private static bool disableException = false;
        [DllImport("MCN8532P.dll")]
        private static extern bool MCN8532P_Open(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern bool MCN8532P_Close(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_LinkCheck(short No);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_BoardReset(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetCardVersion(short No, char* Version);											// Get Card Soft Version
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetMaxAxis(short BoardNo);														// Get Max Axis Control Count
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetConnectAxis(short BoardNo);													// Get Connect Axis Count
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetLogicPos(short BoardNo, short UnitNo, int* Pos);								// Get Axis Logic Position
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetRealPos(short BoardNo, short UnitNo, int* Pos);								// Get Axis Real Position
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetSpeed(short BoardNo, short UnitNo, int* Speed);								// Get Axis Real Speed
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetTorque(short BoardNo, short UnitNo, int* Torque);								// Get Axis Real Torque
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetAxisStatus(short BoardNo, short UnitNo, int* Stat);							// Get Axis Status
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_ReadParameter(short BoardNo, short UnitNo, short ParaNo, int* Data);				// Read Parameter
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_WriteParameter(short BoardNo, short UnitNo, short ParaNo, int Data);				// Write Parameter
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_EepromWriteParameter(short BoardNo, short UnitNo);								// EEPROM Write Parameter
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetEepromWriteParameterStatus(short BoardNo, short UnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetAlarmCode(short BoardNo, short UnitNo, short* ErrCode);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ServoOn(short BoardNo, short UnitNo);												// Servo On
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ServoOff(short BoardNo, short UnitNo);											// Servo Off
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSpeed(short BoardNo, short UnitNo, int StartSpeed, int DriveSpeed, int UpRate, int DownRate, int ScurveTime);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ChangePosOnFly(short BoardNo, short UnitNo, int NewPosition);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ResetUnit(short BoardNo, short UnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetStartSpeed(short No, short UnitNo, int Speed);								// Set Start Speed
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetDriveSpeed(short No, short UnitNo, int Speed);								// Set Drive Speed
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetUpRate(short No, short UnitNo, int Rate);										// Set Up Rate
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetDownRate(short No, short UnitNo, int Rate);									// Set Down Rate
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetScurveTime(short No, short UnitNo, int ScurveTim);									// Set Down Rate
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_AbsMove(short No, short UnitNo, int Position);									// Absolute Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_RelMove(short No, short UnitNo, int Position);									// Relativity Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SlowStop(short No, short UnitNo);													// Move Slow Down Stop
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_InstantlyStop(short No, short UnitNo);											// Move Instantly Stop
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetDriveEnd(short No, short UnitNo);												// Get Drive End Status
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetHomingSpeed(short BoardNo, short UnitNo, int HomeSpeed1, int HomeSpeed2, int HomeAcc, int HomeOffset);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Homing(short No, short UnitNo, short HomeMode);									// Homing
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StopHoming(short BoardNo, short UnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetHomingStatus(short No, short UnitNo);											// Get Homing Finish Status
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSoftLimit(short No, short UnitNo, int PsoftLmt, int NsoftLmt);				// Set Soft Limit Position
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSoftLimitUse(short No, short UnitNo, short Mode);								// Set Soft Limit Use / No Use
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_Input(short No, short UnitNo, int* Data);										// Input Data
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Output(short No, short UnitNo, int Data);										// Output Data
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_ReadOutput(short BoardNo, short UnitNo, int* Data);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_BitOutput(short No, short UnitNo, short Bit, short Data);							// Bit Output
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetUnitType(short No, short UnitNo);												// Get Unit Type (0:No Module,1:Servo Module,2:IN Module,3:OUT Module)
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContinueMove(short No, short UnitNo, short Dir);									// Continue Move
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_StartLog(char* File);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StopLog();
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartStorage(short BoardNo, int Mode);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StopStorage(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetStorageCnt(short BoardNo, short* Cnt);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetStorageData(short No, short Idx, int* Data);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetUnitModel(short BoardNo, short UnitNo, int* Model);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetProductCode(short BoardNo, short UnitNo, int* Pcode);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPosition(short No, short UnitNo, int Position);								// Set Position
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetUnitSubId(short BoardNo, short UnitNo, short* SubId);
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetBoardState(short BoardNo, int* State);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetHardLimitUse(short No, short UnitNo, short P_LS, short N_LS);					// Set Hard Limit Use / No Use
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetLastErrorCode( short BoardNo, int *ErrCode );
        public static bool Open(short BoardNo)
        {
            return MCN8532P_Open(BoardNo);
        }
        public static bool Close(short BoardNo)
        {
            return MCN8532P_Close(BoardNo);
        }
        public static short LinkCheck(short BoardNo)
        {
            return MCN8532P_LinkCheck(BoardNo);
        }
        public static short BoardReset(short BoardNo)
        {
            return Check(MCN8532P_BoardReset(BoardNo));
        }
        //public static short GetCardVersion(short BoardNo, out string Version)
        //{
        //    char[] buf = new char[128];
        //    short ret;
        //    unsafe
        //    {
        //        fixed (char* p = &buf[0])
        //        {
        //            ret = Check(MCN8532P_GetCardVersion(BoardNo, p));
        //        }
        //    }
        //    Version = buf.ToString();
        //    return ret;
        //}
        public static short GetMaxAxis(short BoardNo)
        {
            return MCN8532P_GetMaxAxis(BoardNo);
        }
        public static short GetConnectAxis(short BoardNo)
        {
            return MCN8532P_GetConnectAxis(BoardNo);
        }
        public static short GetLogicPos(short BoardNo, short UnitNo, out int Pos)
        {
            unsafe
            {
                fixed (int* p = &Pos)
                {
                    return Check(MCN8532P_GetLogicPos(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetRealPos(short BoardNo, short UnitNo, out int Pos)
        {
            unsafe
            {
                fixed (int* p = &Pos)
                {
                    return Check(MCN8532P_GetRealPos(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetSpeed(short BoardNo, short UnitNo, out int Speed)
        {
            unsafe
            {
                fixed (int* p = &Speed)
                {
                    return Check(MCN8532P_GetSpeed(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetTorque(short BoardNo, short UnitNo, out int Torque)
        {
            unsafe
            {
                fixed (int* p = &Torque)
                {
                    return Check(MCN8532P_GetTorque(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetAxisStatus(short BoardNo, short UnitNo, out int Status)
        {
            unsafe
            {
                fixed (int* p = &Status)
                {
                    return Check(MCN8532P_GetAxisStatus(BoardNo, UnitNo, p));
                }
            }
        }
        public static short ReadParameter(short BoardNo, short UnitNo, short ParaNo, out int Data)
        {
            unsafe
            {
                fixed (int* p = &Data)
                {
                    return Check(MCN8532P_ReadParameter(BoardNo, UnitNo, ParaNo, p));
                }
            }
        }
        public static short WriteParameter(short BoardNo, short UnitNo, short ParaNo, int Data)
        {
            return Check(MCN8532P_WriteParameter(BoardNo, UnitNo, ParaNo, Data));
        }
        public static short EepromWriteParameter(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_EepromWriteParameter(BoardNo, UnitNo));
        }
        public static short GetEepromWriteParameterStatus(short BoardNo, short UnitNo)
        {
            return MCN8532P_GetEepromWriteParameterStatus(BoardNo, UnitNo);
        }
        public static short GetAlarmCode(short BoardNo, short UnitNo, out short AlarmCode)
        {
            unsafe
            {
                fixed (short* p = &AlarmCode)
                {
                    return Check(MCN8532P_GetAlarmCode(BoardNo, UnitNo, p));
                }
            }
        }
        public static short ServoOn(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_ServoOn(BoardNo, UnitNo));
        }
        public static short ServoOff(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_ServoOff(BoardNo, UnitNo));
        }
        public static short SetSpeed(short BoardNo, short UnitNo, int StartSpeed, int DriveSpeed, int UpRate, int DownRate, int ScurveTime)
        {
            return Check(MCN8532P_SetSpeed(BoardNo, UnitNo, StartSpeed, DriveSpeed, UpRate, DownRate, ScurveTime));
        }
        public static short SetStartSpeed(short BoardNo, short UnitNo, int Speed)
        {
            return Check(MCN8532P_SetStartSpeed(BoardNo, UnitNo, Speed));
        }
        public static short SetDriveSpeed(short BoardNo, short UnitNo, int Speed)
        {
            return Check(MCN8532P_SetDriveSpeed(BoardNo, UnitNo, Speed));
        }
        public static short SetUpRate(short BoardNo, short UnitNo, int UpRate)
        {
            return Check(MCN8532P_SetUpRate(BoardNo, UnitNo, UpRate));
        }
        public static short SetDownRate(short BoardNo, short UnitNo, int DownRate)
        {
            return Check(MCN8532P_SetDownRate(BoardNo, UnitNo, DownRate));
        }
        public static short SetScurveTime(short BoardNo, short UnitNo, int ScurveTime)
        {
            return Check(MCN8532P_SetScurveTime(BoardNo, UnitNo, ScurveTime));
        }
        public static short AbsMove(short BoardNo, short UnitNo, int Position)
        {
            return Check(MCN8532P_AbsMove(BoardNo, UnitNo, Position));
        }
        public static short RelMove(short BoardNo, short UnitNo, int Position)
        {
            return Check(MCN8532P_RelMove(BoardNo, UnitNo, Position));
        }
        public static short ChangePosOnFly(short BoardNo, short UnitNo, int NewPosition)
        {
            return Check(MCN8532P_ChangePosOnFly(BoardNo, UnitNo, NewPosition));
        }
        public static short ResetUnit(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_ResetUnit(BoardNo, UnitNo));
        }
        public static short SlowStop(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_SlowStop(BoardNo, UnitNo));
        }
        public static short InstantlyStop(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_InstantlyStop(BoardNo, UnitNo));
        }
        public static short GetDriveEnd(short BoardNo, short UnitNo)
        {
            return MCN8532P_GetDriveEnd(BoardNo, UnitNo);
        }
        public static short SetHomingSpeed(short BoardNo, short UnitNo, int HomeSpeed1, int HomeSpeed2, int HomeAcc, int HomeOffset)
        {
            return Check(MCN8532P_SetHomingSpeed(BoardNo, UnitNo, HomeSpeed1, HomeSpeed2, HomeAcc, HomeOffset));
        }
        public static short Homing(short BoardNo, short UnitNo, short HomeMode)
        {
            return Check(MCN8532P_Homing(BoardNo, UnitNo, HomeMode));
        }
        public static short StopHoming(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_StopHoming(BoardNo, UnitNo));
        }
        public static short GetHomingStatus(short BoardNo, short UnitNo)
        {
            return MCN8532P_GetHomingStatus(BoardNo, UnitNo);
        }
        public static short SetSoftLimit(short BoardNo, short UnitNo, int PsoftLmt, int NsoftLmt)
        {
            return Check(MCN8532P_SetSoftLimit(BoardNo, UnitNo, PsoftLmt, NsoftLmt));
        }
        public static short SetSoftLimitUse(short BoardNo, short UnitNo, short Use)
        {
            return Check(MCN8532P_SetSoftLimitUse(BoardNo, UnitNo, Use));
        }
        public static short Input(short BoardNo, short UnitNo, out int Data)
        {
            unsafe
            {
                fixed (int* p = &Data)
                {
                    return Check(MCN8532P_Input(BoardNo, UnitNo, p));
                }
            }
        }
        public static short Output(short BoardNo, short UnitNo, int Data)
        {
            return Check(MCN8532P_Output(BoardNo, UnitNo, Data));
        }
        public static short ReadOutput(short BoardNo, short UnitNo, out int Data)
        {
            unsafe
            {
                fixed (int* p = &Data)
                {
                    return Check(MCN8532P_ReadOutput(BoardNo, UnitNo, p));
                }
            }
        }
        public static short BitOutput(short BoardNo, short UnitNo, short Bit, short Data)
        {
            return Check(MCN8532P_BitOutput(BoardNo, UnitNo, Bit, Data));
        }
        public static short GetUnitType(short BoardNo, short UnitNo)
        {
            return MCN8532P_GetUnitType(BoardNo, UnitNo);
        }
        public static short ContinueMove(short BoardNo, short UnitNo, short Dir)
        {
            return Check(MCN8532P_ContinueMove(BoardNo, UnitNo, Dir));
        }
        //public static unsafe short StartLog(char* File)
        //{
        //    return Check(MCN8532P_StartLog(File));
        //}
        //public static unsafe short StopLog()
        //{
        //    return Check(MCN8532P_StopLog());
        //}
        public static short StartStorage(short BoardNo, int Mode)
        {
            return Check(MCN8532P_StartStorage(BoardNo, Mode));
        }
        public static short StopStorage(short BoardNo)
        {
            return Check(MCN8532P_StopStorage(BoardNo));
        }
        public static short GetStorageCnt(short BoardNo, out short Cnt)
        {
            unsafe
            {
                fixed (short* p = &Cnt)
                {
                    return Check(MCN8532P_GetStorageCnt(BoardNo, p));
                }
            }
        }
        public static short GetStorageData(short BoardNo, short Idx, int[] Data)
        {
            short ret;
            unsafe
            {
                fixed (int* p = &Data[0])
                {
                    ret = Check(MCN8532P_GetStorageData(BoardNo, Idx, p));
                }
            }
            return ret;
        }
        public static short GetUnitModel(short BoardNo, short UnitNo, out int Model)
        {
            unsafe
            {
                fixed (int* p = &Model)
                {
                    return Check(MCN8532P_GetUnitModel(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetProductCode(short BoardNo, short UnitNo, out int Pcode)
        {
            unsafe
            {
                fixed (int* p = &Pcode)
                {
                    return Check(MCN8532P_GetProductCode(BoardNo, UnitNo, p));
                }
            }
        }
        public static short SetPosition(short BoardNo, short UnitNo, int Position)
        {
            return Check(MCN8532P_SetPosition(BoardNo, UnitNo, Position));
        }
        public static short GetUnitSubId(short BoardNo, short UnitNo, out short SubId)
        {
            unsafe
            {
                fixed (short* p = &SubId)
                {
                    return Check(MCN8532P_GetUnitSubId(BoardNo, UnitNo, p));
                }
            }
        }
        public static short GetBoardState(short BoardNo, out int State)
        {
            unsafe
            {
                fixed (int* p = &State)
                {
                    return Check(MCN8532P_GetBoardState(BoardNo, p));
                }
            }
        }
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_MultiAxis_OpenModule(short BoardNo, short ModuleNo, short* UnitNo, short UnitCnt);
        public static short MultiAxis_OpenModule(short BoardNo, short ModuleNo, short[] UnitNo)
        {
            unsafe
            {
                fixed (short* p = &UnitNo[0])
                {
                    return Check(MCN8532P_MultiAxis_OpenModule(BoardNo, ModuleNo, p, Convert.ToInt16(UnitNo.Length)));
                }
            }
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_CloseModule(short BoardNo, short ModuleNo);
        public static short MultiAxis_CloseModule(short BoardNo, short ModuleNo)
        {
            return MCN8532P_MultiAxis_CloseModule(BoardNo, ModuleNo);
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_ResetModule(short BoardNo, short ModuleNo);
        public static short MultiAxis_ResetModule(short BoardNo, short ModuleNo)
        {
            return MCN8532P_MultiAxis_ResetModule(BoardNo, ModuleNo);
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetSpeedPara(short BoardNo, short ModuleNo, int UpRate, int DownRate, int ScurveTime, int StartSpeed);
        public static short MultiAxis_SetSpeedPara(short BoardNo, short ModuleNo, int UpRate, int DownRate, int ScurveTime, int StartSpeed)
        {
            return Check(MCN8532P_MultiAxis_SetSpeedPara(BoardNo, ModuleNo, UpRate, DownRate, ScurveTime, StartSpeed));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetSpeed(short BoardNo, short ModuleNo, int Speed);
        public static short MultiAxis_SetSpeed(short BoardNo, short ModuleNo, int Speed)
        {
            return Check(MCN8532P_MultiAxis_SetSpeed(BoardNo, ModuleNo, Speed));
        }
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_MultiAxis_SetLine(short BoardNo, short ModuleNo, int* Distance, short UnitCnt);
        public static short MultiAxis_SetLine(short BoardNo, short ModuleNo, int[] Distance)
        {
            unsafe
            {
                fixed (int* p = &Distance[0])
                {
                    return Check(MCN8532P_MultiAxis_SetLine(BoardNo, ModuleNo, p, Convert.ToInt16(Distance.Length)));
                }
            }
        }
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_MultiAxis_ChangeLinePosOnFly(short BoardNo, short ModuleNo, int* Distance, short UnitCnt);
        public static short MultiAxis_ChangeLinePosOnFly(short BoardNo, short ModuleNo, int[] Distance)
        {
            unsafe
            {
                fixed (int* p = &Distance[0])
                {
                    return Check(MCN8532P_MultiAxis_ChangeLinePosOnFly(BoardNo, ModuleNo, p, Convert.ToInt16(Distance.Length)));
                }
            }
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetArc2d_1(short BoardNo, short ModuleNo, int CenX, int CenY, int EndX, int EndY, int RotDir, int RevCount);
        public static short MultiAxis_SetArc2d_1(short BoardNo, short ModuleNo, int CenX, int CenY, int EndX, int EndY, int RotDir, int RevCount)
        {
            return Check(MCN8532P_MultiAxis_SetArc2d_1(BoardNo, ModuleNo, CenX, CenY, EndX, EndY, RotDir, RevCount));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetArc2d_2(short BoardNo, short ModuleNo, int CenX, int CenY, int Angle);
        public static short MultiAxis_SetArc2d_2(short BoardNo, short ModuleNo, int CenX, int CenY, int Angle)
        {
            return Check(MCN8532P_MultiAxis_SetArc2d_2(BoardNo, ModuleNo, CenX, CenY, Angle));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetArc3d_1(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int EndX, int EndY, int EndZ, int RotDir, int RevCount);
        public static short MultiAxis_SetArc3d_1(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int EndX, int EndY, int EndZ, int RotDir, int RevCount)
        {
            return Check(MCN8532P_MultiAxis_SetArc3d_1(BoardNo, ModuleNo, CenX, CenY, CenZ, EndX, EndY, EndZ, RotDir, RevCount));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetArc3d_2(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int NorX, int NorY, int NorZ, int Angle);
        public static short MultiAxis_SetArc3d_2(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int NorX, int NorY, int NorZ, int Angle)
        {
            return Check(MCN8532P_MultiAxis_SetArc3d_2(BoardNo, ModuleNo, CenX, CenY, CenZ, NorX, NorY, NorZ, Angle));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetHelical_1(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int EndX, int EndY, int EndZ, int NorX, int NorY, int NorZ, int RotDir, int RevCount);
        public static short SetHelical_1(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int EndX, int EndY, int EndZ, int NorX, int NorY, int NorZ, int RotDir, int RevCount)
        {
            return Check(MCN8532P_MultiAxis_SetHelical_1(BoardNo, ModuleNo, CenX, CenY, CenZ, EndX, EndY, EndZ, NorX, NorY, NorZ, RotDir, RevCount));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_SetHelical_2(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int NorX, int NorY, int NorZ, int Angle, int Distance, int EndRadius);
        public static short MultiAxis_SetHelical_2(short BoardNo, short ModuleNo, int CenX, int CenY, int CenZ, int NorX, int NorY, int NorZ, int Angle, int Distance, int EndRadius)
        {
            return Check(MCN8532P_MultiAxis_SetHelical_2(BoardNo, ModuleNo, CenX, CenY, CenZ, NorX, NorY, NorZ, Angle, Distance, EndRadius));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_Start(short BoardNo, short ModuleNo);
        public static short MultiAxis_Start(short BoardNo, short ModuleNo)
        {
            return Check(MCN8532P_MultiAxis_Start(BoardNo, ModuleNo));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_Pause(short BoardNo, short ModuleNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_InstantlyStop(short BoardNo, short ModuleNo);
        public static short MultiAxis_InstantlyStop(short BoardNo, short ModuleNo)
        {
            return Check(MCN8532P_MultiAxis_InstantlyStop(BoardNo, ModuleNo));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_NextNodeWrCheck(short BoardNo, short ModuleNo);														// Next Continue Interpolation Node Write Check
        public static short MultiAxis_NextNodeWrCheck(short BoardNo, short ModuleNo)
        {
            return Check(MCN8532P_MultiAxis_NextNodeWrCheck(BoardNo, ModuleNo));
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_MultiAxis_GetStatus(short BoardNo, short ModuleNo);
        public static short MultiAxis_GetStatus(short BoardNo, short ModuleNo)
        {
            return MCN8532P_MultiAxis_GetStatus(BoardNo, ModuleNo);
        }
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPtTableLength(short BoardNo, short UnitNo, int Length);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPtTableData(short BoardNo, short UnitNo, short Index, int Distance, int Time);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartPtMove(short BoardNo, int Axis);

        ///////////////////////////////////////////////////////////////////////////
        //	PVT commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPvtTableLength(short BoardNo, short UnitNo, int Length);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPvtTableData(short BoardNo, short UnitNo, short Index, int Distance, int Speed, int Time);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartPvtMove(short BoardNo, int Axis);

        ///////////////////////////////////////////////////////////////////////////
        //	E-CAM commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetTableLength(short BoardNo, short UnitNo, int Length);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetTableData(short BoardNo, short UnitNo, short Index, int Distance);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetCommandRate(short BoardNo, short UnitNo, int CmdRate);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetSpeed(short BoardNo, short UnitNo, int Speed);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetOffset(short BoardNo, short UnitNo, int Offset);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetMoveOffset(short BoardNo, short UnitNo, int MoveOffset);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_SetFollowAxis(short BoardNo, short Slave, short Master);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_InitSlaveAxis(short BoardNo, short Slave);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_Start(short BoardNo, short UnitNo, int Axis);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_Pause(short BoardNo, short UnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Ecam_Restart(short BoardNo, short UnitNo);

        ///////////////////////////////////////////////////////////////////////////
        //	E-Gear commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Egear_SetRatio(short BoardNo, short UnitNo, int Molecular, int Denominator);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Egear_Start(short BoardNo, short UnitNo, short Master);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Egear_Stop(short BoardNo, short UnitNo);

        ///////////////////////////////////////////////////////////////////////////
        //	Tangential following commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_PulsesPerRev(short BoardNo, short FollowUnitNo, int Pulses);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_ZeroDegAbsPos(short BoardNo, short FollowUnitNo, int Pos);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_SetModuleNo(short BoardNo, short FollowUnitNo, short ModuleNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_SetFollowDir(short BoardNo, short FollowUnitNo, int FollowDir);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_InverseCommandDir(short BoardNo, short FollowUnitNo, int Inverse);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_InitMove(short BoardNo, short FollowUnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TangentFollow_Start(short BoardNo, short FollowUnitNo);

        ///////////////////////////////////////////////////////////////////////////
        //	Sync Tracing commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Gantry_Init(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Gain, int M_Molecular, int M_Denominator, int Offset, int MaxError);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Gantry_SetHomeSpeed(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int HomeSpeed1, int HomeSpeed2, int HomeAcc, int HomeOffset);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Gantry_HomeMove(short BoardNo, short UnitNo);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Gantry_AbsMove(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Position);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Gantry_RelMove(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Distance);

        ///////////////////////////////////////////////////////////////////////////
        //	Error Compensation commands
        ///////////////////////////////////////////////////////////////////////////
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetMode(short BoardNo, short UnitNo, int Mode);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetBacklash(short BoardNo, short UnitNo, int Backlash);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetPitch(short BoardNo, short UnitNo, int Pitch);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetLinearValue(short BoardNo, short UnitNo, int Value);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetNonlinearTable(short BoardNo, short UnitNo, short Index, int Value);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetNonlinearTableOrigin(short BoardNo, short UnitNo, short Index);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Comp_SetNonlinearTableLength(short BoardNo, short UnitNo, short Length);
        public static short SetPtTableLength(short BoardNo, short UnitNo, int Length)
        {
            return Check(MCN8532P_SetPtTableLength(BoardNo, UnitNo, Length));
        }
        public static short SetPtTableData(short BoardNo, short UnitNo, short Index, int Distance, int Time)
        {
            return Check(MCN8532P_SetPtTableData(BoardNo, UnitNo, Index, Distance, Time));
        }
        public static short StartPtMove(short BoardNo, int Axis)
        {
            return Check(MCN8532P_StartPtMove(BoardNo, Axis));
        }
        public static short SetPvtTableLength(short BoardNo, short UnitNo, int Length)
        {
            return Check(MCN8532P_SetPvtTableLength(BoardNo, UnitNo, Length));
        }
        public static short SetPvtTableData(short BoardNo, short UnitNo, short Index, int Distance, int Speed, int Time)
        {
            return Check(MCN8532P_SetPvtTableData(BoardNo, UnitNo, Index, Distance, Speed, Time));
        }
        public static short StartPvtMove(short BoardNo, int Axis)
        {
            return Check(MCN8532P_StartPvtMove(BoardNo, Axis));
        }
        public static short Ecam_SetTableLength(short BoardNo, short UnitNo, int Length)
        {
            return Check(MCN8532P_Ecam_SetTableLength(BoardNo, UnitNo, Length));
        }
        public static short Ecam_SetTableData(short BoardNo, short UnitNo, short Index, int Distance)
        {
            return Check(MCN8532P_Ecam_SetTableData(BoardNo, UnitNo, Index, Distance));
        }
        public static short Ecam_SetCommandRate(short BoardNo, short UnitNo, int CmdRate)
        {
            return Check(MCN8532P_Ecam_SetCommandRate(BoardNo, UnitNo, CmdRate));
        }
        public static short Ecam_SetSpeed(short BoardNo, short UnitNo, int Speed)
        {
            return Check(MCN8532P_Ecam_SetSpeed(BoardNo, UnitNo, Speed));
        }
        public static short Ecam_SetOffset(short BoardNo, short UnitNo, int Offset)
        {
            return Check(MCN8532P_Ecam_SetSpeed(BoardNo, UnitNo, Offset));
        }
        public static short Ecam_SetMoveOffset(short BoardNo, short UnitNo, int MoveOffset)
        {
            return Check(MCN8532P_Ecam_SetMoveOffset(BoardNo, UnitNo, MoveOffset));
        }
        public static short Ecam_SetFollowAxis(short BoardNo, short Slave, short Master)
        {
            return Check(MCN8532P_Ecam_SetFollowAxis(BoardNo, Slave, Master));
        }
        public static short Ecam_InitSlaveAxis(short BoardNo, short Slave)
        {
            return Check(MCN8532P_Ecam_InitSlaveAxis(BoardNo, Slave));
        }
        public static short Ecam_Start(short BoardNo, short UnitNo, int Axis)
        {
            return Check(MCN8532P_Ecam_Start(BoardNo, UnitNo, Axis));
        }
        public static short Ecam_Pause(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_Ecam_Pause(BoardNo, UnitNo));
        }
        public static short Ecam_Restart(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_Ecam_Restart(BoardNo, UnitNo));
        }
        public static short Egear_SetRatio(short BoardNo, short UnitNo, int Molecular, int Denominator)
        {
            return Check(MCN8532P_Egear_SetRatio(BoardNo, UnitNo, Molecular, Denominator));
        }
        public static short Egear_Start(short BoardNo, short UnitNo, short Master)
        {
            return Check(MCN8532P_Egear_Start(BoardNo, UnitNo, Master));
        }
        public static short Egear_Stop(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_Egear_Stop(BoardNo, UnitNo));
        }
        public static short TangentFollow_PulsesPerRev(short BoardNo, short FollowUnitNo, int Pulses)
        {
            return Check(MCN8532P_TangentFollow_PulsesPerRev(BoardNo, FollowUnitNo, Pulses));
        }
        public static short TangentFollow_ZeroDegAbsPos(short BoardNo, short FollowUnitNo, int Pos)
        {
            return Check(MCN8532P_TangentFollow_ZeroDegAbsPos(BoardNo, FollowUnitNo, Pos));
        }
        public static short TangentFollow_SetModuleNo(short BoardNo, short FollowUnitNo, short ModuleNo)
        {
            return Check(MCN8532P_TangentFollow_SetModuleNo(BoardNo, FollowUnitNo, ModuleNo));
        }
        public static short TangentFollow_SetFollowDir(short BoardNo, short FollowUnitNo, int FollowDir)
        {
            return Check(MCN8532P_TangentFollow_SetFollowDir(BoardNo, FollowUnitNo, FollowDir));
        }
        public static short TangentFollow_InverseCommandDir(short BoardNo, short FollowUnitNo, int Inverse)
        {
            return Check(MCN8532P_TangentFollow_InverseCommandDir(BoardNo, FollowUnitNo, Inverse));
        }
        public static short TangentFollow_InitMove(short BoardNo, short FollowUnitNo)
        {
            return Check(MCN8532P_TangentFollow_InitMove(BoardNo, FollowUnitNo));
        }
        public static short TangentFollow_Start(short BoardNo, short FollowUnitNo)
        {
            return Check(MCN8532P_TangentFollow_Start(BoardNo, FollowUnitNo));
        }
        public static short Gantry_Init(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Gain, int M_Molecular, int M_Denominator, int Offset, int MaxError)
        {
            return Check(MCN8532P_Gantry_Init(BoardNo, SlaveUnitNo, MasterUnitNo, Gain, M_Molecular, M_Denominator, Offset, MaxError));
        }
        public static short Gantry_SetHomeSpeed(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int HomeSpeed1, int HomeSpeed2, int HomeAcc, int HomeOffset)
        {
            return Check(MCN8532P_Gantry_SetHomeSpeed(BoardNo, SlaveUnitNo, MasterUnitNo, HomeSpeed1, HomeSpeed2, HomeAcc, HomeOffset));
        }
        public static short Gantry_HomeMove(short BoardNo, short UnitNo)
        {
            return Check(MCN8532P_Gantry_HomeMove(BoardNo, UnitNo));
        }
        public static short Gantry_AbsMove(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Position)
        {
            return Check(MCN8532P_Gantry_AbsMove(BoardNo, SlaveUnitNo, MasterUnitNo, Position));
        }
        public static short Gantry_RelMove(short BoardNo, short SlaveUnitNo, short MasterUnitNo, int Distance)
        {
            return Check(MCN8532P_Gantry_RelMove(BoardNo, SlaveUnitNo, MasterUnitNo, Distance));
        }
        public static short Comp_SetMode(short BoardNo, short UnitNo, int Mode)
        {
            return Check(MCN8532P_Comp_SetMode(BoardNo, UnitNo, Mode));
        }
        public static short Comp_SetBacklash(short BoardNo, short UnitNo, int Backlash)
        {
            return Check(MCN8532P_Comp_SetBacklash(BoardNo, UnitNo, Backlash));
        }
        public static short Comp_SetPitch(short BoardNo, short UnitNo, int Pitch)
        {
            return Check(MCN8532P_Comp_SetPitch(BoardNo, UnitNo, Pitch));
        }
        public static short Comp_SetLinearValue(short BoardNo, short UnitNo, int Value)
        {
            return Check(MCN8532P_Comp_SetLinearValue(BoardNo, UnitNo, Value));
        }
        public static short Comp_SetNonlinearTable(short BoardNo, short UnitNo, short Index, int Value)
        {
            return Check(MCN8532P_Comp_SetNonlinearTable(BoardNo, UnitNo, Index, Value));
        }
        public static short Comp_SetNonlinearTableOrigin(short BoardNo, short UnitNo, short Index)
        {
            return Check(MCN8532P_Comp_SetNonlinearTableOrigin(BoardNo, UnitNo, Index));
        }
        public static short Comp_SetNonlinearTableLength(short BoardNo, short UnitNo, short Length)
        {
            return Check(MCN8532P_Comp_SetNonlinearTableLength(BoardNo, UnitNo, Length));
        }
        public static short GetLastErrorCode(short BoardNo, out int ErrCode)
        {
            unsafe
            {
                fixed (int* p = &ErrCode)
                {
                    return Check(MCN8532P_GetLastErrorCode(BoardNo, p));
                }
            }
        }
        public static void EnableException()
        {
            disableException = false;
        }
        public static void DisableException()
        {
            disableException = true;
        }
    }
}
