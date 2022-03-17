using System;
using System.Collections.Generic;
using System.Text;

//建立存款和提款
//您的銀行帳戶必須能接受存款及提款，才算能正常運作。 
//讓我們透過建立帳戶每一筆交易的日誌，來實作存款和提款。 
//相較於單純地在每次交易時更新餘額，建立日誌能提供數個好處。 
//該記錄可用來對所有交易進行稽核，以及管理每日餘額。 
//藉由在必要時計算所有交易記錄的餘額，在任何單一交易中已修正的錯誤都會正確地在下一次計算中反映出來。

namespace 物件導向程式設計
{
    class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
