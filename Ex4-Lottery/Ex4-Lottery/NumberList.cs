using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_Lottery
{
    public class NumberList : LottoList
    {

        protected List<int> ResultList;

        private static readonly Random random = new Random(DateTime.Now.Millisecond+1);
        private static readonly object syncLock = new object();

        public NumberList(int ListID, DateTime PlayDate, DateTime PurchaseDate, int MerchantNo)
            : base(ListID, PlayDate, PurchaseDate, MerchantNo)
        {

        }

        public List<int> GetResultList()
        {
            return ResultList;
        }

        public override List<int> CreateResultList()
        {
            List<int> container = new List<int>(49);
            ResultList = new List<int>(6);
            for (int i = 1; i <= 49; i++)
            {
                container.Add(i);
            }
            int index = 0;
            int value = 0;
            for (int i = 1; i <= 6; i++)
            {
                lock (syncLock)
                {
                    index = random.Next(0, container.Count);
                }
                value = container[index];
                ResultList.Add(value);
                container.RemoveAt(index);
            }
            ResultList.Sort();
            return ResultList;
        } 

    }
}
