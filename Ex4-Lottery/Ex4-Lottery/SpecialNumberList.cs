using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_Lottery
{
    class SpecialNumberList : NumberList
    {

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private int bonus = 0;

        public SpecialNumberList(int ListID, DateTime PlayDate, DateTime PurchaseDate, int MerchantNo)
            : base(ListID, PlayDate, PurchaseDate, MerchantNo)
        {

        }

        public void DisplayBonusNumber()
        {
            Console.WriteLine("Bonus number: ");
            Console.Write("---- ");
            Console.Write(bonus.ToString("D2"));
            Console.Write(" ----");
        }

        public int GetBonusNumber()
        {
            do
            {
                bonus = random.Next(1, 50);
            } while (ResultList.Contains(bonus));
            return bonus;
        }

        /*public override List<int> CreateResultList()
        {
            List<int> container = new List<int>(49);
            ResultList = new List<int>(7);   // 6 regular numbers + 1 bonus number
            for (int i = 1; i <= 49; i++)
            {
                container.Add(i);
            }
            int index = 0;
            int value = 0;
            for (int i = 1; i <= 7; i++)
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
        }*/

    }
}
