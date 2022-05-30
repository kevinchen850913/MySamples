using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Aurotek;

namespace MCT8132P_Gantry
{
    class MotionModel
    {
        //主站從站編號
        public short BoardNo = 0;
        public short IO = 7;
        public short ServoA = 5;
        public short ServoB = 6;
        public short StepA = 1;
        public short StepB = 2;

        public int StepLimitPos = 1600;
        public int ServoLimitPos = 120000;

        public bool FreeGantry = true;

        private int StepPosA, StepPosB, StepPosC;

        public void InitBoard()
        {
            MCT8132P.Open(BoardNo);
            MCT8132P.BoardReset(BoardNo);
        }

        public bool LinkCheck()
        {
            return MCT8132P.LinkCheck(BoardNo) == 0;
        }

        public void ServoInit()
        {
            ServoOn();
            Stop();
            SetHomingSpeed();
            SetHighSpeed();
        }
        private void ServoOn()
        {
            MCT8132P.ServoOn(BoardNo, ServoA);
            MCT8132P.ServoOn(BoardNo, ServoB);
            MCT8132P.ServoOn(BoardNo, StepA);
            MCT8132P.ServoOn(BoardNo, StepB);
        }

        private void SetHomingSpeed()
        {
            MCT8132P.SetHomingSpeed(BoardNo, ServoA, 20000, 10000, 10000000, 0);
            MCT8132P.SetHomingSpeed(BoardNo, ServoB, 20000, 10000, 10000000, 0);
        }

        private void SetLowSpeed()
        {
            MCT8132P.SetSpeed(BoardNo, ServoA, 1000, 20000, 200000, 200000, 0);
            MCT8132P.SetSpeed(BoardNo, ServoB, 1000, 20000, 200000, 200000, 0);
            MCT8132P.SetSpeed(BoardNo, StepA, 100, 100, 1000, 1000, 0);
            MCT8132P.SetSpeed(BoardNo, StepB, 100, 100, 1000, 1000, 0);
        }

        public void SetHighSpeed()
        {
            MCT8132P.SetSpeed(BoardNo, ServoA, 1000, 50000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, ServoB, 1000, 50000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, StepA, 500, 1000, 100000, 100000, 0);
            MCT8132P.SetSpeed(BoardNo, StepB, 500, 1000, 100000, 100000, 0);

            /*測試使用高速度
            MCT8132P.SetSpeed(BoardNo, ServoA, 1000, 200000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, ServoB, 1000, 200000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, StepA, 500, 1500, 100000, 100000, 0);
            MCT8132P.SetSpeed(BoardNo, StepB, 500, 1500, 100000, 100000, 0);
             * */
        }

        public void SetHighSpeed2()
        {
            MCT8132P.SetSpeed(BoardNo, ServoA, 1000, 100000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, ServoB, 1000, 100000, 4000000, 4000000, 0);
            MCT8132P.SetSpeed(BoardNo, StepA, 500, 2000, 100000, 100000, 0);
            MCT8132P.SetSpeed(BoardNo, StepB, 500, 2000, 100000, 100000, 0);
        }

        public void Close()
        {
            try
            {
                Stop();
                MCT8132P.ServoOff(BoardNo, ServoA);
                MCT8132P.ServoOff(BoardNo, ServoB);
                MCT8132P.ServoOff(BoardNo, StepA);
                MCT8132P.ServoOff(BoardNo, StepB);
                MCT8132P.Close(BoardNo);
            }
            catch (Exception e)
            {
            }
        }

        public void ServoHoming()
        {
            MCT8132P.Homing(BoardNo, ServoA, 7);
            MCT8132P.Homing(BoardNo, ServoB, 7);
        }

    

        public bool ServoHomingCheck()
        {
            short s1, s2;
            s1 = MCT8132P.GetHomingStatus(BoardNo, ServoA);
            s2 = MCT8132P.GetHomingStatus(BoardNo, ServoB);
            return s1 == 0 && s2 == 0;
        }

        public void ServoHomingOffset()
        {
            SetLowSpeed();
            MCT8132P.ResetUnit(BoardNo, ServoA);
            MCT8132P.ResetUnit(BoardNo, ServoB);
            MCT8132P.RelMove(BoardNo, ServoA, -2 * ServoLimitPos);
            MCT8132P.RelMove(BoardNo, ServoB, -2 * ServoLimitPos);
        }
        

        public bool ServoHomingOffsetCheckAndStop()
        {
            string str1, str2;
            int n = 0;
            MCT8132P.GetAxisStatus(BoardNo, ServoA, out n);
            str1 = Convert.ToString(n, 2).PadLeft(32, '0');
            MCT8132P.GetAxisStatus(BoardNo, ServoB, out n);
            str2 = Convert.ToString(n, 2).PadLeft(32, '0');
            if (str1[22] == '0')
            {
                MCT8132P.InstantlyStop(BoardNo, ServoA);
            }
            if (str2[22] == '0')
            {
                MCT8132P.InstantlyStop(BoardNo, ServoB);
            }
            return str1[22] == '0' && str2[22] == '0';
        }

        public void ServoGantryInit()
        {
            MCT8132P.InstantlyStop(BoardNo, ServoA);
            MCT8132P.InstantlyStop(BoardNo, ServoB);
            MCT8132P.Gantry_Init(BoardNo, ServoA, ServoB, 0, 1, 1,-5800, 1000);
        }

        public void StepHoming()
        {
            SetLowSpeed();
            MCT8132P.ResetUnit(BoardNo, StepA);
            if (CheckIOSensor())
            {
                MCT8132P.RelMove(BoardNo, StepA, StepLimitPos);  
            }       
            return;
        }

        public void StepAPTP(int Pos)
        {
            SetHighSpeed();
            MCT8132P.ResetUnit(BoardNo, StepA);
            MCT8132P.RelMove(BoardNo, StepA, Pos);
            return;
        }

        public void StepBInitPTP()
        {
            SetHighSpeed();
            MCT8132P.ResetUnit(BoardNo, StepB);
            MCT8132P.AbsMove(BoardNo, StepB, 0);
            return;
        }

        public bool StepHomingCheck()
        {
            return MCT8132P.GetDriveEnd(BoardNo, StepA) != 0;
        }

        public void StepHomingStop()
        {
            MCT8132P.InstantlyStop(BoardNo, StepA);
            MCT8132P.GetRealPos(BoardNo, StepA, out StepPosA);
            MCT8132P.GetRealPos(BoardNo, StepB, out StepPosB);
        }

        public void StepHomingOffset()
        {
            SetLowSpeed();
            MCT8132P.ResetUnit(BoardNo, StepA);
            MCT8132P.RelMove(BoardNo, StepA, StepLimitPos);
        }

        public void StepHomingStopOffset()
        {
            SetLowSpeed();
            MCT8132P.InstantlyStop(BoardNo, StepA);
            MCT8132P.GetRealPos(BoardNo, StepA, out StepPosC);
            MCT8132P.Gantry_Init(BoardNo, StepA, StepB, 0, -1, 1, (StepPosA + StepPosB + StepPosC + StepPosB) / 2, 1000);
        }

        //CheckIOSensor為True時感測器沒對齊
        public bool CheckIOSensor()
        {
            int data = 0;
            MCT8132P.Input(BoardNo, IO, out data);
            FreeGantry = data % 2 == 1;
            return FreeGantry;
        }

        //CheckDriveEnd為True時該軸正在動作
        public bool CheckDriveEnd(short UnitNo)
        {
            return MCT8132P.GetDriveEnd(BoardNo, UnitNo) != 0;
        }

        public void Stop()
        {
            MCT8132P.ResetUnit(BoardNo, StepA);
            MCT8132P.ResetUnit(BoardNo, StepB);
            MCT8132P.InstantlyStop(BoardNo, ServoA);
            MCT8132P.InstantlyStop(BoardNo, ServoB);
            MCT8132P.InstantlyStop(BoardNo, StepA);
            MCT8132P.InstantlyStop(BoardNo, StepB);
        }

        public void ServoGantryA()
        {
            MCT8132P.ResetUnit(BoardNo, ServoA);
            MCT8132P.ResetUnit(BoardNo, ServoB);
            MCT8132P.Gantry_RelMove(BoardNo, ServoA, ServoB, -ServoLimitPos);
        }

        public void ServoGantryB()
        {
            MCT8132P.ResetUnit(BoardNo, ServoA);
            MCT8132P.ResetUnit(BoardNo, ServoB);
            MCT8132P.Gantry_RelMove(BoardNo, ServoA, ServoB, ServoLimitPos);
        }

        public void StepGantryA()
        {
            MCT8132P.ResetUnit(BoardNo, StepA);
            MCT8132P.ResetUnit(BoardNo, StepB);
            MCT8132P.Gantry_RelMove(BoardNo, StepA, StepB, -StepLimitPos/2);
        }

        public void StepGantryB()
        {
            MCT8132P.ResetUnit(BoardNo, StepA);
            MCT8132P.ResetUnit(BoardNo, StepB);
            MCT8132P.Gantry_RelMove(BoardNo, StepA, StepB, StepLimitPos/2);
        }

    }
}
