// 1A2B.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//
//任務目標清單
//1.確認輸入功能 OK
//2.基本1A2B判斷 OK
//3.自動題目生成 OK
// 
//下一街動任務目標
//電腦玩家功能(亂度最平均算法)
//1.爆開所有可能答案的解
//2.第一次隨機猜測
//3.把可能的解套入隨機猜測
//	，若答案不同就直接刪除
//4.可能答案的解分別套入隨機猜測
//5.若可將剩餘答案最平均分散
//	，則為局部最佳解
//6.進行實際猜測
//7.重複3~6直到得到正解
// 
//其他任務目標
//1.AI對抗功能
//2.計分功能
//3.程式碼整理

#include <iostream>
#include <sstream>  
#include <cstdlib> /* 亂數相關函數 */
#include <ctime>   /* 時間相關函數 */

using namespace std;

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
answer toanswer(string str)
{
	answer rt = {};
	int n = toNum(str);
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

int main()
{
	string s = "";
	int i = 0;
	game G1 = game();
	while (true)
	{
		switch (i)
		{
		case 0:
			cout << "開始 !"<< endl;
			G1 = game();
			i = 1;
			break;
		case 1:
			cout << "請輸入數字 " << endl;
			cin >> s;
			G1.run(toanswer(s));
			if (G1.win)
			{
				i = 0;
			}
			break;
		case 2:
			break;
		default:
			i = 0;
			break;
		}
	}
}

