using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_Lottery
{
    public abstract class LottoList
    {
        protected int ListID;
        protected DateTime PlayDate;
        protected DateTime PurchaseDate;
        protected int MerchantNo;

        public LottoList(int ListID, DateTime PlayDate, DateTime PurchaseDate, int MerchantNo)
        {
            this.ListID = ListID;
            this.PlayDate = PlayDate;
            this.PurchaseDate = PurchaseDate;
            this.MerchantNo = MerchantNo;
        }

        public void DisplayListID()
        {
            Console.Write("Quick Pick " + ListID + ": ");
        }

        public void DisplayPlayDate()
        {
            Console.Write("   " + PlayDate.ToShortDateString());
        }

        public void DisplayPurchaseDate()
        {
            Console.Write("    " + PurchaseDate.ToShortDateString());
        }

        public void DisplayMerchantNo()
        {
            Console.Write("        " + MerchantNo);
        }

        public abstract List<int> CreateResultList();

        
    }
}
