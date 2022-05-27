using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSharp
{
    class MCT81XX
    {
        //System Commands Function
        [DllImport("MCT81XX.dll", EntryPoint = "MCT81XX_Open", CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 MCT81XX_Open(short board_no);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_Close(short board_no);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_CloseAll();
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_BoardReset(short board_no);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_LinkCheck(short board_no);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_ServoOn(short board_no, byte UnitNo);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_ServoOff(short board_no, byte UnitNo);
        [DllImport("MCT81XX.dll")]
        public static extern short MCT81XX_GetUnitType(short No, short UnitNo);

        [DllImport("MCT81XX.dll")]
        public static extern short MCT81XX_Input(short No, short UnitNo, ref long Data);
        [DllImport("MCT81XX.dll")]
        public static extern short MCT81XX_Output(short No, short UnitNo, long Data);
        [DllImport("MCT81XX.dll")]
        public static extern short MCT81XX_ReadOutput(short BoardNo, short UnitNo, ref long Data);

        //Read Commands Function
        [DllImport("MCT81XX.dll")]
        public static extern short MCT81XX_ReadParameter(short board_no, short UnitNo, short ParaNo, ref int ParaRetValue);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_GetMaxAxis(byte board_no);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_GetConnectAxis(byte board_no);

        //Write Commands Function
        [DllImport("MCT81XX.dll")]
        public static extern int MCT81XX_WriteParameter(byte board_no, byte UnitNo, byte ParaNo, Int32 ParaRetValue);
        [DllImport("MCT81XX.dll")]
        public static extern int MCT81XX_EepromWriteParameter(byte board_no, byte UnitNo);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_SetSpeed(byte board_no, Int16 UnitNo, int StartSpeed, int DriveSpeed, int UpRate, int DownRate, int ScurveTime);

        //Driving Commands Function
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_AbsMove(byte board_no, byte UnitNo, int Position);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_RelMove(byte board_no, byte UnitNo, int Distance);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_ChangePosOnFly(byte board_no, byte UnitNo, int NewPosition);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_ContinueMove(byte board_no, byte UnitNo, int MoveDir);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_SlowStop(byte board_no, byte UnitNo);
        [DllImport("MCT81XX.dll")]
        public static extern Int16 MCT81XX_InstantlyStop(byte board_no, byte UnitNo);
    }
}
