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

#include "1A2B.h"
using namespace _1A2B;

void player(game G)
{
	while (!G.win)
	{
		string s = "";
		cout << "請輸入數字 " << endl;
		cin >> s;
		G.run(toanswer(s));
	}
}

void robotplayer1(game G)
{
	robotplayer R1 = robotplayer();
	R1.run(G);
}

int main()
{
	
	int i = 0;
	game G1 = game();
	while (true)
	{
		switch (i)
		{
		case 0:
			cout << "開始 !"<< endl;
			system("pause");
			G1 = game();
			i = 2;
			break;
		case 1:
			player(G1);
			break;
		case 2:
			cout << "暴力解 " << endl;
			robotplayer1(G1);
			i = 0;
			break;
		default:
			i = 0;
			break;
		}
	}
}

