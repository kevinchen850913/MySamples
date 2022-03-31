#pragma once
#include <iostream>
#include <sstream>  
#include <cstdlib> /* 亂數相關函數 */
#include <ctime>   /* 時間相關函數 */

using namespace std;

namespace _1A2B
{
	struct answer
	{
		bool regular = false;
		int num[4] = {};      //不重複四位數字
		int counter[10] = {}; //使用哪些數字
		int A = 0;
		int B = 0;
	};

	int toNum(string str)
	{
		stringstream sin(str);
		unsigned int n;
		return sin >> n ? n : 0;
	}
	answer randanswer()
	{
		answer rt;
		srand(time(NULL));
		for (int i = 0; i < 4;)
		{
			int x = rand() % 10;
			if (rt.counter[x] != 1)
			{
				rt.counter[x] = 1;
				rt.num[i] = x;
				i++;
			}
		}
		rt.regular = true;
		return rt;
	}
	answer toanswer(int n)
	{
		answer rt = {};
		if (n <= 123 || n >= 9876)
		{
			cout << "格式錯誤 : 無效的輸入!\n";
			return rt;
		}
		for (int i = 3; i >= 0; i--, n = n / 10)
		{
			rt.num[i] = n % 10;
			if (rt.counter[rt.num[i]] != 0)
			{
				cout << "格式錯誤 : 數字有重複\n";
				return rt;
			}
			rt.counter[rt.num[i]]++;
		}
		rt.regular = true;
		return rt;
	}
	answer toanswer(string str)
	{
		int n = toNum(str);
		return toanswer(n);
	}

	class game
	{
	public:
		bool win;
		answer correctanswer;
		answer myanswer;
		int counter;
		game()
		{
			win = false;
			correctanswer = randanswer();
			counter = 0;
		}
		void checkanswer()
		{
			if (!correctanswer.regular || !myanswer.regular)
				return;
			for (int i = 0; i < 4; i++)
			{
				if (correctanswer.num[i] == myanswer.num[i])
					myanswer.A++;
				else
					myanswer.B += correctanswer.counter[myanswer.num[i]];
			}
			return;
		}
		void printmyanswer()
		{
			if (!correctanswer.regular || !myanswer.regular)
				return;
			cout << "我的答案 : ";
			for (auto i : myanswer.num)
				cout << i;
			cout << endl;
			if (myanswer.A == 4)
			{
				win = true;
				cout << " 過關 !" << endl;
				cout << "總共猜了" << counter << "次" << endl;
			}
			else
				cout << "A = " << myanswer.A << " ,B = " << myanswer.B << endl;
		}
		void run(answer answer)
		{
			counter++;
			myanswer = answer;
			checkanswer();
			printmyanswer();
		}
	};
	class robotplayer
	{
	public:
		game g;
		answer temp = {};
		int offset = 0;
		robotplayer()
		{
		}
		void run(game G)
		{
			g = G;
			temp.regular = true;
			tryanswer();
		}
		void tryanswer()
		{
			if (offset > 4)
			{
				return;
			}
			if (offset == 4)
			{
				g.run(temp);
				if (g.win)
				{
					offset = 100;
					return;
				}
			}
			for (int i = 0; i < 10; i++)
			{
				if (temp.counter[i] == 0)
				{
					temp.num[offset % 10] = i;
					temp.counter[i] = 1;
					offset++;
					tryanswer();
					offset--;
					temp.counter[i] = 0;
				}
			}
		}
	};
}
