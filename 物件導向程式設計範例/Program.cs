using System;
using System.Collections.Generic;
using System.Text;

//此檔案將包含 *bank 帳戶 _ 的定義。 物件導向程式設計會以 _ 類別 * 的形式建立類型來組織程式碼。 這些類別包含代表特定實體的程式碼。 BankAccount 類別代表銀行帳戶。 程式碼會透過方法和屬性來實作特定的作業。 在此教學課程中，銀行帳戶支援此行為：

//它具有能唯一識別銀行帳戶的 10 位數數字。
//它具有能儲存擁有者一個或多個名稱的字串。
//可擷取餘額。
//它接受存款。
//它接受提款。
//初始餘額必須為正數。
//提款不可使餘額成為負數。

namespace 物件導向程式設計
{
    class Program
    {
        static void Main(string[] args)
        {
            //當您使用建立物件時，會呼叫此函數 new 。 
            //以 Console.WriteLine("Hello World!"); 下列程式碼取代 Program 中的 程式 程式碼 (取代 <name> 為您的名稱) ：
            var account = new BankAccount("<name>", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            //應該對建構函式進行一項變更來使它會新增初始交易，而不是直接更新餘額。
            ////由於您已撰寫 MakeDeposit 方法，請從建構函式呼叫它，完成的建構函式應該看起來如下。
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            //此方法使用 StringBuilder 類別來設定針對每個交易包含單一行之字串的格式。
            //您稍早已經在這些教學課程中看過字串格式設定的程式碼。 一個新的字元是 \t。
            //它會插入定位字元以設定輸出的格式。
            Console.WriteLine(account.GetAccountHistory());

            //試建立具有負餘額的帳戶，以測試您是否正在攔截錯誤狀況。
            //使用 try 和 catch 語句來標記可能會擲回例外狀況的程式碼區塊，並攔截您預期的錯誤。
            //您可以使用相同的技巧來測試擲回例外狀況的程式碼，以取得負餘額。 
            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
