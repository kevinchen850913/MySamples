using System.Runtime.InteropServices;
using System.Text;

namespace Aurotek
{
    class MCT81XX
    {
        [DllImport("MCN8532P.dll")]
        private static extern bool MCN8532P_Open(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern bool MCN8532P_Close(short BoardNo);
        [DllImport("MCN8532P.dll")]
        private static extern bool  MCN8532P_CloseAll();
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_LinkCheck( short No );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ServoReset( short BoardNo );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_AlarmReset( short BoardNo );														// Alarm Reset
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetCardVersion( short No, StringBuilder Version );											// Get Card Soft Version
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetMaxAxis( short BoardNo );														// Get Max Axis Control Count
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetConnectAxis( short BoardNo );													// Get Connect Axis Count
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetLogicPos( short BoardNo, short UnitNo, int *Pos );								// Get Axis Logic Position
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetRealPos( short BoardNo, short UnitNo, int *Pos );								// Get Axis Real Position
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetSpeed( short BoardNo, short UnitNo, int *Speed );								// Get Axis Real Speed
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetTorque( short BoardNo, short UnitNo, int *Torque );								// Get Axis Real Torque
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetAxisStatus( short BoardNo, short UnitNo, int *Stat );							// Get Axis Status
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_ReadParameter( short BoardNo, short UnitNo, short ParaNo, int *Data );				// Read Parameter
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_WriteParameter( short BoardNo, short UnitNo, short ParaNo, int Data );				// Write Parameter
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_EepromWriteParameter( short BoardNo, short UnitNo );								// EEPROM Write Parameter
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetAlarmCode( short No, short UnitNo, short Index, short *Alarm, short *Warning );	// Get Alarm Code
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ServoOn( short BoardNo, short UnitNo );												// Servo On
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ServoOff( short BoardNo, short UnitNo );											// Servo Off
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GainChange( short BoardNo, short UnitNo, short GainNo );							// Gain Switch Change
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TorqueLimitChange( short BoardNo, short UnitNo, short TorqueNo );					// Torque Limit Change
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ExOut( short BoardNo, short UnitNo, short OutNo, short Mode );						// User Output ON/OFF Control
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetStartSpeed( short No, short UnitNo, int Speed );								// Set Start Speed
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetDriveSpeed( short No, short UnitNo, int Speed );								// Set Drive Speed
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetUpRate( short No, short UnitNo, int Rate );										// Set Up Rate
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetDownRate( short No, short UnitNo, int Rate );									// Set Down Rate
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetOriginSpeed1( short No, short UnitNo, int Speed );								// Set Origin Speed 1
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetOriginSpeed2( short No, short UnitNo, int Speed );								// Set origin Speed 2
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_AbsMove( short No, short UnitNo, int Position );									// Absolute Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_RelMove( short No, short UnitNo, int Position );									// Relativity Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TriggerAbsMove( short No, short UnitNo, int Position, int IntervalPls, short OutTime, short OutNo );	// Trigger Output Absolute Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_TriggerRelMove( short No, short UnitNo, int Position, int IntervalPls, short OutTime, short OutNo );	// Trigger Output Relativity Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetLineMoveAxis( short No, short UnitNo, int Position, short PosType );			// Set Line Move Axis & Position
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ResetLineMoveAxis( short No );														// Reset All Line Move Axis Setting
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartLineMove( short No );															// Start Line Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_CirMove( short No, short UnitNo1, int PassPos1A, int PassPos1B, short UnitNo2, int PassPos2A, int PassPos2B );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ArcMove( short No, short UnitNo1, int PassPos1, int EndPos1, short UnitNo2, int PassPos2, int EndPos2 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContinueCirMove( short No, short UnitNo1, int PassPos1A, int PassPos1B, short UnitNo2, int PassPos2A, int PassPos2B );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContinueArcMove( short No, short UnitNo1, int PassPos1, int EndPos1, short UnitNo2, int PassPos2, int EndPos2 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetFirstCirFollowAxis( short No, short UnitNo1, int PassPos1A, int PassPos1B, short UnitNo2, int PassPos2A, int PassPos2B );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetFirstArcFollowAxis( short No, short UnitNo1, int PassPos1, int EndPos1, short UnitNo2, int PassPos2, int EndPos2 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetNextFollowAxis( short No, short UnitNo );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartFollow( short No );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SlowStop( short No, short UnitNo );													// Move Slow Down Stop
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_InstantlyStop( short No, short UnitNo );											// Move Instantly Stop
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetDriveEnd( short No, short UnitNo );												// Get Drive End Status
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetPosition( short No, short UnitNo, int Position );								// Set Position
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Homing( short No, short UnitNo, short HomeMode );									// Homing
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetHomingStatus( short No, short UnitNo );											// Get Homing Finish Status
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSoftLimit( short No, short UnitNo, int PsoftLmt, int NsoftLmt );				// Set Soft Limit Position
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSoftLimitUse( short No, short UnitNo, short Mode );								// Set Soft Limit Use / No Use
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetHardLimitUse( short No, short UnitNo, short P_LS, short N_LS );					// Set Hard Limit Use / No Use
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_Input( short No, short UnitNo, int *Data );										// Input Data
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Output( short No, short UnitNo, int Data );										// Output Data
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_BitOutput( short No, short UnitNo, short Bit, short Data );							// Bit Output
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SyncAbsMove( short No, short Master, short Slave, short SlaveDir, short Ratio, int Position );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SyncRelMove( short No, short Master, short Slave, short SlaveDir, short Ratio, int Position );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SetSyncLineAxis( short No, short Master, short Slave, short SlaveDir, short Ratio, int Position, short PosType );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ResetSyncLineAxis( short No );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartSyncLineMove( short No );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetUnitType( short No, short UnitNo );												// Get Unit Type (0:No Module,1:Servo Module,2:IN Module,3:OUT Module)
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SyncCirMove( short No, short Master1, int PassPos1A, int PassPos1B, short Master2, int PassPos2A, int PassPos2B, short Slave1, short SlaveDir1, short Ratio1, short Slave2, short SlaveDir2, short Ratio2 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_SyncArcMove( short No, short Master1, int PassPos1, int EndPos1, short Master2, int PassPos2, int EndPos2, short Slave1, short SlaveDir1, short Ratio1, short Slave2, short SlaveDir2, short Ratio2 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContinueMove( short No, short UnitNo, short Dir );									// Continue Move
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContinueLineMove( short No, short UnitNo1, int Pos1, short UnitNo2, int Pos2, short PosType );	// Continue Line Interpolation
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_NextNodeWrCheck( short No );														// Next Continue Interpolation Node Write Check
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_StartLog(string File);
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StopLog();
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetStopLog( short No, char *File );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StartStorage( short No, short UnitNo1, short UnitNo2, short UnitNo3, short UnitNo4 );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_StopStorage( short No );
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetStorageCnt( short No, short *Cnt );
        [DllImport("MCN8532P.dll")]
        private static extern unsafe short MCN8532P_GetStorageData( short No, short Idx, int *LogicPos, int *RealPos );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContInpStopOn( short No, short UnitNo, short InpNo, short StopMode );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_ContInpStopOff( short No, short UnitNo );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Sensor_Stop( short No, short UnitNo, short InpNo1, short InpNo2, short RunMode, int MaxPulse );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_Sensor_Edge( short No, short UnitNo, short InpNo, short RunMode, short StopMode, int MaxPulse, int MinPulse );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_GetSensorHomingStatus( short No, short UnitNo );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_InterpolationEndCheck( short No );
        [DllImport("MCN8532P.dll")]
        private static extern short MCN8532P_InterpolateEndCheck( short No );
		bool Open( short BoardNo )
		{
			return MCN8532P_Open( BoardNo );
		}
		
    }
}
