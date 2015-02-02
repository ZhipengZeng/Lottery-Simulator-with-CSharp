using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_Lottery
{
    public class QuickPickList<T> : IEnumerable<T>
        where T : LottoList
    {

        private List<T> lottolists = new List<T>();

        public List<T> LottoLists
        {
            get
            {
                return lottolists;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return LottoLists.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return LottoLists.GetEnumerator();
        }

        public void GetResultLists()
        {
            foreach (T numberlist in LottoLists)
            {
                numberlist.CreateResultList();
            }
        }

    }
}
