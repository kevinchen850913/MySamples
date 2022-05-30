using System;
using System.Collections.Generic;
using System.Text;
using Aurotek;

namespace MCT8132P_Gantry
{
    class IOModel
    {
        static short BoardNo = 0;
        static short UnitNo = 8;
        static int OnTimeCount = 5;
        static int StateCount = 1000;
        static int Count = 0;

        Queue<char> q_TextInput = new Queue<char>();
        string InputText = "!321GO@";
        bool IsLoop = true;

        static int[][] Dotmatrixtable = new int[][] { 
            new int[] { 0x0000, 0x0000, 0xfe00, 0x8200, 0x8200, 0xfe00, 0x0000, 0x0000 },//0
            new int[] { 0x0000, 0x0000, 0x0000, 0x8200, 0xfe00, 0x8000, 0x0000, 0x0000 },//1
            new int[] { 0x0000, 0x0000, 0xf200, 0x9200, 0x9200, 0x9e00, 0x0000, 0x0000 },//2
            new int[] { 0x0000, 0x0000, 0x9200, 0x9200, 0x9200, 0xfe00, 0x0000, 0x0000 },//3
            new int[] { 0x0000, 0x0000, 0x1e00, 0x1000, 0x1000, 0xfe00, 0x0000, 0x0000 },//4
            new int[] { 0x0000, 0x0000, 0x9e00, 0x9200, 0x9200, 0xf200, 0x0000, 0x0000 },//5
            new int[] { 0x0000, 0x0000, 0xfe00, 0x9200, 0x9200, 0xf200, 0x0000, 0x0000 },//6
            new int[] { 0x0000, 0x0000, 0x0200, 0x0200, 0x0200, 0xfe00, 0x0000, 0x0000 },//7
            new int[] { 0x0000, 0x0000, 0xfe00, 0x9200, 0x9200, 0xfe00, 0x0000, 0x0000 },//8
            new int[] { 0x0000, 0x0000, 0x9e00, 0x9200, 0x9200, 0xfe00, 0x0000, 0x0000 },//9
            new int[] { 0x0000, 0xfc00, 0x2600, 0x2200, 0x2600, 0xfc00, 0x0000, 0x0000 },//A
            new int[] { 0x0000, 0xfe00, 0x9200, 0x9200, 0x9200, 0xfc00, 0x0000, 0x0000 },//B
            new int[] { 0x0000, 0x7c00, 0xc600, 0x8200, 0x8200, 0x8200, 0x0000, 0x0000 },//C
            new int[] { 0x0000, 0xfe00, 0x8200, 0x8200, 0xc600, 0x7c00, 0x0000, 0x0000 },//D
            new int[] { 0x0000, 0xfe00, 0x9200, 0x9200, 0x9200, 0x9200, 0x0000, 0x0000 },//E
            new int[] { 0x0000, 0xfe00, 0x1200, 0x1200, 0x1200, 0x0200, 0x0000, 0x0000 },//F
            new int[] { 0x0000, 0xfe00, 0x8200, 0x9200, 0x9200, 0xf200, 0x0000, 0x0000 },//G
            new int[] { 0x0000, 0xfe00, 0x1000, 0x1000, 0x1000, 0xfe00, 0x0000, 0x0000 },//H
            new int[] { 0x0000, 0x8200, 0x8200, 0xfe00, 0x8200, 0x8200, 0x0000, 0x0000 },//I
            new int[] { 0x0000, 0x8200, 0x8200, 0x8200, 0xfe00, 0x0200, 0x0000, 0x0000 },//J
            new int[] { 0x0000, 0xfe00, 0x1000, 0x2800, 0x4400, 0x8200, 0x0000, 0x0000 },//K
            new int[] { 0x0000, 0xfe00, 0x8000, 0x8000, 0x8000, 0x8000, 0x0000, 0x0000 },//L
            new int[] { 0x0000, 0xfe00, 0x0200, 0xfc00, 0x0200, 0xfe00, 0x0000, 0x0000 },//M
            new int[] { 0x0000, 0xfe00, 0x0c00, 0x3000, 0xc000, 0xfe00, 0x0000, 0x0000 },//N
            new int[] { 0x0000, 0x7c00, 0xc600, 0x8200, 0xc600, 0x7c00, 0x0000, 0x0000 },//O
            new int[] { 0x0000, 0xfe00, 0x2200, 0x2200, 0x2200, 0x3e00, 0x0000, 0x0000 },//P
            new int[] { 0x0000, 0x7c00, 0xc600, 0xa200, 0x4600, 0xbc00, 0x0000, 0x0000 },//Q
            new int[] { 0x0000, 0xfe00, 0x2200, 0x6200, 0xe200, 0xbe00, 0x0000, 0x0000 },//R
            new int[] { 0x0000, 0x9e00, 0x9200, 0x9200, 0x9200, 0xf200, 0x0000, 0x0000 },//S
            new int[] { 0x0000, 0x0200, 0x0200, 0xfe00, 0x0200, 0x0200, 0x0000, 0x0000 },//T
            new int[] { 0x0000, 0x7e00, 0x8000, 0x8000, 0x8000, 0x7e00, 0x0000, 0x0000 },//U
            new int[] { 0x0000, 0x3e00, 0x6000, 0xc000, 0x6000, 0x3e00, 0x0000, 0x0000 },//V
            new int[] { 0x0000, 0xfe00, 0x8000, 0xfe00, 0x8000, 0xfe00, 0x0000, 0x0000 },//W
            new int[] { 0x0000, 0xc600, 0x6c00, 0x1000, 0x6c00, 0xc600, 0x0000, 0x0000 },//X
            new int[] { 0x0000, 0x0e00, 0x1800, 0xf000, 0x1800, 0x0e00, 0x0000, 0x0000 },//Y
            new int[] { 0x0000, 0xc200, 0xa200, 0x9200, 0x8a00, 0x8600, 0x0000, 0x0000 } //Z
        };

        public void LED_charToArray(char c)
        {
            switch (c)
            {
                case '!':
                    LED_Mode_1();
                    break;
                case '@':
                    LED_Mode_2();
                    break;

                case '0':
                    LED_Print(Dotmatrixtable[0]);
                    break;
                case '1':
                    LED_Print(Dotmatrixtable[1]);
                    break;
                case '2':
                    LED_Print(Dotmatrixtable[2]);
                    break;
                case '3':
                    LED_Print(Dotmatrixtable[3]);
                    break;
                case '4':
                    LED_Print(Dotmatrixtable[4]);
                    break;
                case '5':
                    LED_Print(Dotmatrixtable[5]);
                    break;
                case '6':
                    LED_Print(Dotmatrixtable[6]);
                    break;
                case '7':
                    LED_Print(Dotmatrixtable[7]);
                    break;
                case '8':
                    LED_Print(Dotmatrixtable[8]);
                    break;
                case '9':
                    LED_Print(Dotmatrixtable[9]);
                    break;
                case 'A':
                    LED_Print(Dotmatrixtable[10]);
                    break;
                case 'B':
                    LED_Print(Dotmatrixtable[11]);
                    break;
                case 'C':
                    LED_Print(Dotmatrixtable[12]);
                    break;
                case 'D':
                    LED_Print(Dotmatrixtable[13]);
                    break;
                case 'E':
                    LED_Print(Dotmatrixtable[14]);
                    break;
                case 'F':
                    LED_Print(Dotmatrixtable[15]);
                    break;
                case 'G':
                    LED_Print(Dotmatrixtable[16]);
                    break;
                case 'H':
                    LED_Print(Dotmatrixtable[17]);
                    break;
                case 'I':
                    LED_Print(Dotmatrixtable[18]);
                    break;
                case 'J':
                    LED_Print(Dotmatrixtable[19]);
                    break;
                case 'K':
                    LED_Print(Dotmatrixtable[20]);
                    break;
                case 'L':
                    LED_Print(Dotmatrixtable[21]);
                    break;
                case 'M':
                    LED_Print(Dotmatrixtable[22]);
                    break;
                case 'N':
                    LED_Print(Dotmatrixtable[23]);
                    break;
                case 'O':
                    LED_Print(Dotmatrixtable[24]);
                    break;
                case 'P':
                    LED_Print(Dotmatrixtable[25]);
                    break;
                case 'Q':
                    LED_Print(Dotmatrixtable[26]);
                    break;
                case 'R':
                    LED_Print(Dotmatrixtable[27]);
                    break;
                case 'S':
                    LED_Print(Dotmatrixtable[28]);
                    break;
                case 'T':
                    LED_Print(Dotmatrixtable[29]);
                    break;
                case 'U':
                    LED_Print(Dotmatrixtable[30]);
                    break;
                case 'V':
                    LED_Print(Dotmatrixtable[31]);
                    break;
                case 'W':
                    LED_Print(Dotmatrixtable[32]);
                    break;
                case 'X':
                    LED_Print(Dotmatrixtable[33]);
                    break;
                case 'Y':
                    LED_Print(Dotmatrixtable[34]);
                    break;
                case 'Z':
                    LED_Print(Dotmatrixtable[35]);
                    break;
            }
            return;
        }

        public void QueueAddText()
        {
            q_TextInput = new Queue<char>();
            for (int i = 0; i < InputText.Length; i++)
            {
                q_TextInput.Enqueue(InputText[i]);
            }
        }

        public void Run()
        {   
            if (q_TextInput.Count > 0)
            {
                if (Count >= StateCount)
                {
                    LED_charToArray(q_TextInput.Dequeue());
                    Count = 0;
                }
                else
                {
                    LED_charToArray(q_TextInput.Peek());
                }
            }
            else if (IsLoop)
            {
                QueueAddText();
            }
        }

        private static void LED_Print(int[] nums)
        {
            for (int k = Count; k < Count + OnTimeCount && k < StateCount; k++)
            {
                int Data;
                int i = (int)k / (StateCount / 8);
                int j = 7 - (int)k % 8;
                Data = 0x00000000;
                Data += 0x00030000 << i;
                Data += nums[j];
                Data += 0x00000001 << j;
                MCT8132P.Output(BoardNo, UnitNo, Data);
            }
            Count += OnTimeCount;
        }

        private static void LED_Mode_1()
        {
            for (int k = Count; k < Count + OnTimeCount && k < StateCount; k++)
            {
                int Data = 0x00ffffff;
                MCT8132P.Output(BoardNo, UnitNo, Data);
            }
            Count += OnTimeCount;
        }


        private static void LED_Mode_2()
        {
            for (int k = Count; k < Count + OnTimeCount && k < StateCount; k++)
            {
                int Data = 0;
                int i = (int)k / (StateCount / 3);
                int j = (int)k % (StateCount / 3) / 32;
                if (i == 0)
                {
                    Data = 0x00ffff00;
                    Data += 0x1 << j;
                    MCT8132P.Output(BoardNo, UnitNo, Data);
                }
                else if (i == 1)
                {
                    Data = 0x00ff00ff;
                    Data += 0x100 << j;
                    MCT8132P.Output(BoardNo, UnitNo, Data);
                }
                else if (i == 2)
                {
                    Data = 0x0000ffff;
                    Data += 0x10000 << j;
                    MCT8132P.Output(BoardNo, UnitNo, Data);
                }     
            }
            Count += OnTimeCount;
        }
    }
}
