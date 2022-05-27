



#ifndef __MCT81XX_H
#define __MCT81XX_H

#define EX_OUT_ON 1
#define EX_OUT_OFF 0

#define SET_ON 1
#define SET_OFF 0

#define ABS_PLS 0
#define REL_PLS 1

#define SAME_DIR 0
#define REVERSE_DIR 1

#define MaxMultiContNo 6

///////////////////////////////////////////////////////////////////////////
//	Driver
///////////////////////////////////////////////////////////////////////////
#ifdef __cplusplus
extern "C" {
#endif

#define MCT81XX_API __declspec( dllexport )






	









MCT81XX_API BOOL  __stdcall MCT81XX_Open( short BoardNo );																// Board Open
MCT81XX_API BOOL  __stdcall MCT81XX_Close( short BoardNo );																// Board Close
MCT81XX_API BOOL  __stdcall MCT81XX_CloseAll( void );																	// All Board Close
MCT81XX_API short __stdcall MCT81XX_LinkCheck( short BoardNo );																// Link Cable Disconnect Check
MCT81XX_API short __stdcall MCT81XX_GetEsmState( short BoardNo, unsigned short *state );										// Get state of ESM
MCT81XX_API short __stdcall MCT81XX_BoardReset( short BoardNo );														// Servo Driver Reset
MCT81XX_API short __stdcall MCT81XX_CreateUnitMap( short BoardNo, DWORD *UnitMap, DWORD sizeOfUnitMap );
MCT81XX_API short __stdcall MCT81XX_AlarmReset( short BoardNo );														// Alarm Reset
MCT81XX_API short __stdcall MCT81XX_ServoReset( short BoardNo );														// Servo Reset
MCT81XX_API short __stdcall MCT81XX_GetCardVersion( short BoardNo, char *Version );											// Get Card Soft Version
MCT81XX_API short __stdcall MCT81XX_GetMaxAxis( short BoardNo );														// Get Max Axis Control Count
MCT81XX_API short __stdcall MCT81XX_GetConnectAxis( short BoardNo );													// Get Connect Axis Count
MCT81XX_API short __stdcall MCT81XX_GetLogicPos( short BoardNo, short UnitNo, long *Pos );								// Get Axis Logic Position
MCT81XX_API short __stdcall MCT81XX_GetRealPos( short BoardNo, short UnitNo, long *Pos );								// Get Axis Real Position
MCT81XX_API short __stdcall MCT81XX_GetSpeed( short BoardNo, short UnitNo, long *Speed );								// Get Axis Real Speed
MCT81XX_API short __stdcall MCT81XX_GetTorque( short BoardNo, short UnitNo, long *Torque );								// Get Axis Real Torque
MCT81XX_API short __stdcall MCT81XX_GetAxisStatus( short BoardNo, short UnitNo, long *Stat );							// Get Axis Status
MCT81XX_API short __stdcall MCT81XX_ReadParameter( short BoardNo, short UnitNo, short ParaNo, short SubIndex, long *ParaValue );				// Read Parameter
MCT81XX_API short __stdcall MCT81XX_WriteParameter( short BoardNo, short UnitNo, short ParaNo, short SubIndex, long ParaValue );				// Write Parameter
MCT81XX_API short __stdcall MCT81XX_EepromWriteParameter( short BoardNo, short UnitNo );								// EEPROM Write Parameter
MCT81XX_API short __stdcall MCT81XX_GetEepromWriteParameterStatus( short BoardNo, short UnitNo );						// Get EEPROM Write Parameter Status
MCT81XX_API short __stdcall MCT81XX_GetAlarmCode( short BoardNo, short UnitNo, unsigned short *ErrorCode );							// Get Error Code
MCT81XX_API short __stdcall MCT81XX_ServoOn( short BoardNo, short UnitNo );												// Servo On
MCT81XX_API short __stdcall MCT81XX_ServoOff( short BoardNo, short UnitNo );											// Servo Off
MCT81XX_API short __stdcall MCT81XX_SetSpeed( short BoardNo, short UnitNo, long StartSpeed, long DriveSpeed, long UpRate, long DownRate, long ScurveTime );
MCT81XX_API short __stdcall MCT81XX_SetStartSpeed( short BoardNo, short UnitNo, long StartSpeed );								// Set Start Speed
MCT81XX_API short __stdcall MCT81XX_SetDriveSpeed( short BoardNo, short UnitNo, long DriveSpeed );								// Set Drive Speed
MCT81XX_API short __stdcall MCT81XX_SetUpRate( short BoardNo, short UnitNo, long UpRate );										// Set Up Rate
MCT81XX_API short __stdcall MCT81XX_SetDownRate( short BoardNo, short UnitNo, long DownRate );									// Set Down Rate
MCT81XX_API short __stdcall MCT81XX_SetScurveTime( short BoardNo, short UnitNo, long ScurveTime );									// Set S-Curve Time
MCT81XX_API short __stdcall MCT81XX_AbsMove( short BoardNo, short UnitNo, long Position );									// Absolute Move
MCT81XX_API short __stdcall MCT81XX_RelMove( short BoardNo, short UnitNo, long Position );									// Relativity Move
MCT81XX_API short __stdcall MCT81XX_PTP_Resume( short BoardNo, short UnitNo );
MCT81XX_API short __stdcall MCT81XX_ChangePosOnFly( short BoardNo, short UnitNo, long NewPosition );						// Change Position On Fly
MCT81XX_API short __stdcall MCT81XX_ResetUnit( short BoardNo, short UnitNo );
MCT81XX_API short __stdcall MCT81XX_SlowStop( short BoardNo, short UnitNo );													// Move Slow Down Stop
MCT81XX_API short __stdcall MCT81XX_InstantlyStop( short BoardNo, short UnitNo );											// Move Instantly Stop
MCT81XX_API short __stdcall MCT81XX_GetDriveEnd( short BoardNo, short UnitNo );												// Get Drive End Status
MCT81XX_API short __stdcall MCT81XX_SetHomingSpeed( short BoardNo, short UnitNo, long HomeSpeed1, long HomeSpeed2, long HomeAcc, long HomeOffset );	// Set Homing Speed
MCT81XX_API short __stdcall MCT81XX_Homing( short BoardNo, short UnitNo, short HomeMode );									// Homing
MCT81XX_API short __stdcall MCT81XX_StopHoming( short BoardNo, short UnitNo );												// Stop Homing
MCT81XX_API short __stdcall MCT81XX_GetHomingStatus( short BoardNo, short UnitNo );											// Get Homing Finish Status
MCT81XX_API short __stdcall MCT81XX_SetSoftLimit( short BoardNo, short UnitNo, long PsoftLmt, long NsoftLmt );				// Set Soft Limit Position
MCT81XX_API short __stdcall MCT81XX_SetSoftLimitUse( short BoardNo, short UnitNo, short Use );								// Set Soft Limit Use / BoardNo Use
MCT81XX_API short __stdcall MCT81XX_Input( short BoardNo, short UnitNo, long *InputValue );										// Input Data
MCT81XX_API short __stdcall MCT81XX_Output( short BoardNo, short UnitNo, long OutputValue );										// Output Data
MCT81XX_API short __stdcall MCT81XX_ReadOutput( short BoardNo, short UnitNo, long *OutputValue );
MCT81XX_API short __stdcall MCT81XX_BitOutput( short BoardNo, short UnitNo, short Bit, short OutputLevel );					// Bit Output
MCT81XX_API short __stdcall MCT81XX_GetUnitType( short BoardNo, short UnitNo );												// Get Unit Type )(0:BoardNo Module,1:Servo Module,2:IN Module,3:OUT Module)
MCT81XX_API short __stdcall MCT81XX_ContinueMove( short BoardNo, short UnitNo, short MoveDir );									// Continue Move
MCT81XX_API short __stdcall MCT81XX_ContinueMultiLineMove( short BoardNo, short TotalUnit, short *UnitNo, long *Pos, short PosType );		// Continue Line Interpolation)( Over 2 Axis )
MCT81XX_API short __stdcall MCT81XX_StartLog( const char *File );
MCT81XX_API short __stdcall MCT81XX_StopLog( void );
MCT81XX_API short __stdcall MCT81XX_StartStorage( short BoardNo, long Mode );
MCT81XX_API short __stdcall MCT81XX_StopStorage( short BoardNo );
MCT81XX_API short __stdcall MCT81XX_GetStorageCnt( short BoardNo, short *Cnt );
MCT81XX_API short __stdcall MCT81XX_GetStorageData( short BoardNo, short Index, long *Data );
MCT81XX_API short __stdcall MCT81XX_GetUnitModel( short BoardNo, short UnitNo, unsigned long *Model );
MCT81XX_API short __stdcall MCT81XX_GetProductCode( short BoardNo, short UnitNo, unsigned long *Pcode );
MCT81XX_API short __stdcall MCT81XX_SetPosition( short BoardNo, short UnitNo, long NewPos );
MCT81XX_API short __stdcall MCT81XX_GetUnitSubId( short BoardNo, short UnitNo, short *SubId );
MCT81XX_API short __stdcall MCT81XX_GetBoardState( short BoardNo, long *State);

///////////////////////////////////////////////////////////////////////////
//	Multi-Axis commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_MultiAxis_OpenModule( short BoardNo, short ModuleNo, short *UnitNo, short UnitCnt );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_CloseModule( short BoardNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_ResetModule( short BoardNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetSpeedPara( short BoardNo, short ModuleNo, long UpRate, long DownRate, long ScurveTime, long StartSpeed );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetSpeed( short BoardNo, short ModuleNo, long Speed );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetLine( short BoardNo, short ModuleNo, long *Distance, short UnitCnt );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_ChangeLinePosOnFly( short BoardNo, short ModuleNo, long *Distance, short UnitCnt );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetArc2d_1( short BoardNo, short ModuleNo, long CenX, long CenY, long EndX, long EndY, long RotDir, long RevCount );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetArc2d_2( short BoardNo, short ModuleNo, long CenX, long CenY, long Angle );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetArc3d_1( short BoardNo, short ModuleNo, long CenX, long CenY, long CenZ, long EndX, long EndY, long EndZ, long RotDir, long RevCount );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetArc3d_2( short BoardNo, short ModuleNo, long CenX, long CenY, long CenZ, long NorX, long NorY, long NorZ, long Angle );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetHelical_1( short BoardNo, short ModuleNo, long CenX, long CenY, long CenZ, long EndX, long EndY, long EndZ, long NorX, long NorY, long NorZ, long RotDir, long RevCount );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetHelical_2( short BoardNo, short ModuleNo, long CenX, long CenY, long CenZ, long NorX, long NorY, long NorZ, long Angle, long Distance, long EndRadius );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_Start( short BoardNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_Pause( short BoardNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_InstantlyStop( short BoardNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_NextNodeWrCheck( short BoardNo, short ModuleNo );														// Next Continue Interpolation Node Write Check
MCT81XX_API short __stdcall MCT81XX_MultiAxis_SetLines3d( short BoardNo, short ModuleNo, long Distance[][3], long Count, long Radius );
MCT81XX_API short __stdcall MCT81XX_MultiAxis_GetStatus( short BoardNo, short ModuleNo );

///////////////////////////////////////////////////////////////////////////
//	PT commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_SetPtTableLength( short BoardNo, short UnitNo, long Length );
MCT81XX_API short __stdcall MCT81XX_SetPtTableData( short BoardNo, short UnitNo, short Index, long Distance, long Time );
MCT81XX_API short __stdcall MCT81XX_StartPtMove( short BoardNo, unsigned long Axis );

///////////////////////////////////////////////////////////////////////////
//	PVT commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_SetPvtTableLength( short BoardNo, short UnitNo, long Length );
MCT81XX_API short __stdcall MCT81XX_SetPvtTableData( short BoardNo, short UnitNo, short Index, long Distance, long Speed, long Time );
MCT81XX_API short __stdcall MCT81XX_StartPvtMove( short BoardNo, unsigned long Axis );

///////////////////////////////////////////////////////////////////////////
//	E-CAM commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_Ecam_SetTableLength( short BoardNo, short UnitNo, long Length );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetTableData( short BoardNo, short UnitNo, short Index, long Distance );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetCommandRate( short BoardNo, short UnitNo, long CmdRate );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetSpeed( short BoardNo, short UnitNo, long Speed );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetOffset( short BoardNo, short UnitNo, long Offset );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetMoveOffset( short BoardNo, short UnitNo, long MoveOffset );
MCT81XX_API short __stdcall MCT81XX_Ecam_SetFollowAxis( short BoardNo, short Slave, short Master );
MCT81XX_API short __stdcall MCT81XX_Ecam_InitSlaveAxis( short BoardNo, short Slave );
MCT81XX_API short __stdcall MCT81XX_Ecam_Start( short BoardNo, short UnitNo, long Axis );
MCT81XX_API short __stdcall MCT81XX_Ecam_Pause( short BoardNo, short UnitNo );
MCT81XX_API short __stdcall MCT81XX_Ecam_Restart( short BoardNo, short UnitNo );

///////////////////////////////////////////////////////////////////////////
//	E-Gear commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_Egear_SetRatio( short BoardNo, short UnitNo, long Molecular, long Denominator );
MCT81XX_API short __stdcall MCT81XX_Egear_Start( short BoardNo, short UnitNo, short Master );
MCT81XX_API short __stdcall MCT81XX_Egear_Stop( short BoardNo, short UnitNo );

///////////////////////////////////////////////////////////////////////////
//	Tangential following commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_TangentFollow_PulsesPerRev( short BoardNo, short FollowUnitNo, long Pulses );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_ZeroDegAbsPos( short BoardNo, short FollowUnitNo, long Pos );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_SetModuleNo( short BoardNo, short FollowUnitNo, short ModuleNo );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_SetFollowDir( short BoardNo, short FollowUnitNo, long FollowDir );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_InverseCommandDir( short BoardNo, short FollowUnitNo, long Inverse );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_InitMove( short BoardNo, short FollowUnitNo );
MCT81XX_API short __stdcall MCT81XX_TangentFollow_Start( short BoardNo, short FollowUnitNo );

///////////////////////////////////////////////////////////////////////////
//	Sync Tracing commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_Gantry_Init( short BoardNo, short SlaveUnitNo, short MasterUnitNo, long Gain, long M_Molecular, long M_Denominator, long Offset, long MaxError );
MCT81XX_API short __stdcall MCT81XX_Gantry_SetHomeSpeed( short BoardNo, short MasterUnitNo, long HomeSpeed1, long HomeSpeed2, long HomeAcc, long HomeOffset );
MCT81XX_API short __stdcall MCT81XX_Gantry_HomeMove( short BoardNo, short SlaveUnitNo, short MasterUnitNo, short HomeMode );
MCT81XX_API short __stdcall MCT81XX_Gantry_AbsMove( short BoardNo, short SlaveUnitNo, short MasterUnitNo, long Position );
MCT81XX_API short __stdcall MCT81XX_Gantry_RelMove( short BoardNo, short SlaveUnitNo, short MasterUnitNo, long Distance );

///////////////////////////////////////////////////////////////////////////
//	Error Compensation commands
///////////////////////////////////////////////////////////////////////////
MCT81XX_API short __stdcall MCT81XX_Comp_SetMode( short BoardNo, short UnitNo, long Mode );
MCT81XX_API short __stdcall MCT81XX_Comp_SetBacklash( short BoardNo, short UnitNo, long Backlash );
MCT81XX_API short __stdcall MCT81XX_Comp_SetPitch( short BoardNo, short UnitNo, long Pitch );
MCT81XX_API short __stdcall MCT81XX_Comp_SetLinearValue( short BoardNo, short UnitNo, long Value );
MCT81XX_API short __stdcall MCT81XX_Comp_SetNonlinearTable( short BoardNo, short UnitNo, short Index, long Value );
MCT81XX_API short __stdcall MCT81XX_Comp_SetNonlinearTableOrigin( short BoardNo, short UnitNo, short Index );
MCT81XX_API short __stdcall MCT81XX_Comp_SetNonlinearTableLength( short BoardNo, short UnitNo, short Length );













#ifdef __cplusplus
}	// extern "C"
#endif

///////////////////////////////////////////////////////////////////////////
//	Error Code
///////////////////////////////////////////////////////////////////////////

#define PP_RUNNING 2
#define HOMING_NOW 1
#define HOMING_FINISH 0

#define NO_ERR 0
#define LINK_ERR -1
#define CARD_OPEN_ERR -2
#define UNIT_NO_ERR -3
#define PARA_WR_ERR -4
#define PARAMETER_ERR -5
#define AXIS_BUSY -6
#define LINE_AXIS_ERR -7
#define HOMING_ERR -8
#define CIR_CENTER_ERR -9
#define MODULE_ERR -10
#define FOLLOW_ERR -11
#define SYNC_AXIS_ERR -12
#define AXIS_ERR -13
#define CARD_NO_ERR -14
#define DATA_ERR -51
#define TotalUnit_ERR -52
#define MODULE_NO_ERR -54
#define UNIT_CNT_ERR -55
#define PARA_RD_ERR -56
#define PARA_WR_BUSY -57
#define LOG_RUNNING -58
#define MULTI_AXIS_BUSY -59
#define MULTI_AXIS_ERR -60
#define INTERNAL_ERR_0 -200
#define INTERNAL_ERR_1 -201
#define INTERNAL_ERR_2 -202
#define INTERNAL_ERR_3 -203
#define INTERNAL_ERR_4 -204
#define INTERNAL_ERR_5 -205
#define INTERNAL_ERR_6 -206
#define INTERNAL_ERR_7 -207
#define INTERNAL_ERR_8 -208
#define INTERNAL_ERR_9 -209
#define INTERNAL_ERR_10 -210
#define INTERNAL_ERR_11 -211
#define INTERNAL_ERR_12 -212
#define INTERNAL_ERR_13 -213
#define INTERNAL_ERR_14 -214
#define INTERNAL_ERR_15 -215
#define INTERNAL_ERR_16 -216
#define INTERNAL_ERR_17 -217
#define INTERNAL_ERR_18 -218
#define INTERNAL_ERR_19 -219
#define INTERNAL_ERR_20 -220
#define INTERNAL_ERR_21 -221
#define INTERNAL_ERR_22 -222
#define INTERNAL_ERR_23 -223
#define INTERNAL_ERR_24 -224
#define INTERNAL_ERR_25 -225
#define INTERNAL_ERR_26 -226
#define INTERNAL_ERR_27 -227
#define INTERNAL_ERR_28 -228
#define INTERNAL_ERR_29 -229
#define INTERNAL_ERR_30 -230
#define INTERNAL_ERR_31 -231
#define INTERNAL_ERR_32 -232
#define INTERNAL_ERR_33 -233
#define INTERNAL_ERR_34 -234
#define INTERNAL_ERR_35 -235
#define INTERNAL_ERR_36 -236
#define INTERNAL_ERR_98 -298
#define INTERNAL_ERR_99 -299

#define A4N 1
#define A5N 2
#define MCRTEX 3
#define D4610 4

#endif	// __MCT81XX_H
