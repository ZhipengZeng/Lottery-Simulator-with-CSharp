using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4_Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            String Again;
            do
            {
                //
            // Lottery begins.
            //
            Console.Write("How many Quick Picks do you want? ");
            string input = Console.ReadLine();
            int times = Convert.ToInt32(input);

            //
            // Create a quickpick list to store all the numberlist.
            //
            QuickPickList<NumberList> quickpicklist = new QuickPickList<NumberList>();
            
            //
            // Add the regular numberlists to quickpick list.
            //
            for (int i = 1; i <= times; i++)
            {
                quickpicklist.LottoLists.Add(new NumberList(i,new DateTime(2015,01,28),new DateTime(2015,01,27), 100));
            }

            //
            // Create random numbers into all the numberlists.
            //
            quickpicklist.GetResultLists();
            Console.Write("\n");

            //
            // Display each regular numberlist and its information.
            //
            Console.WriteLine("\t\t\t\t    PlayDate    PurchaseDate    MerchantNo");
            foreach (var sublist in quickpicklist)
            {
                sublist.DisplayListID();
                foreach (int number in sublist.GetResultList())
                {
                    Console.Write(number.ToString("D2"));
                    Console.Write(" ");
                }
                sublist.DisplayPlayDate();
                sublist.DisplayPurchaseDate();
                sublist.DisplayMerchantNo();
                Console.WriteLine("\n");
            }

            //
            // Create a winning list.
            //
            SpecialNumberList winninglist = new SpecialNumberList(99999, new DateTime(2015, 01, 28), new DateTime(2015, 01, 27), 100);
            
            //
            // Add the winning list into quickpick list.
            //
            quickpicklist.LottoLists.Add(winninglist);
            winninglist.CreateResultList();
            
            //
            // Display the winning list(except the last number - the bonus) and the information.
            //
            Console.Write("Winning numbers: \n");
            Console.Write("----");
            foreach (var item in winninglist.GetResultList())
            {
                Console.Write(" ");
                Console.Write(item.ToString("D2"));
                Console.Write(" ");
            }
            Console.Write("----");
            winninglist.DisplayPlayDate();
            winninglist.DisplayPurchaseDate();
            winninglist.DisplayMerchantNo();
            Console.WriteLine("\n");

            //
            // Get and Display the bonus number.
            //
            winninglist.GetBonusNumber();
            winninglist.DisplayBonusNumber();

            //
            // Get the result of this Quick Pick lottery.
            //
            bool Win = false;
            Console.WriteLine("\n\nResult:");
            for (int i = 0; i < quickpicklist.Count() - 1; i++)
            {
                quickpicklist.LottoLists[i].DisplayListID();
                List<int> lottoresult = GetLottoResult(quickpicklist.LottoLists[i].GetResultList(), winninglist.GetResultList());

                switch (lottoresult.Count)
                {
                    case 0:
                        Console.Write(" No Matching Numbers ");
                        break;
                    
                    case 1: 
                        foreach (var item in lottoresult)
                        {
                            Console.Write(" " + item.ToString("D2") + " ");
                        }
                        break;
                    case 2:
                        if (quickpicklist.LottoLists[i].GetResultList().Contains(winninglist.GetBonusNumber()))
                        {
                            Win = true;
                            foreach (var item in lottoresult)
                            {
                                Console.Write(" " + item.ToString("D2") + " ");
                            }
                            Console.Write("+ " + winninglist.GetBonusNumber());
                            Console.Write("\tCongratulation! You are winning $5 prize!");
                            
                        }
                        else
                        {
                            foreach (var item in lottoresult)
                            {
                                Console.Write(" " + item.ToString("D2") + " ");
                            }
                        }
                        break;
                    case 3:
                        Win = true;
                        foreach (var item in lottoresult)
                        {
                            Console.Write(" " + item.ToString("D2") + " ");
                        }
                        Console.Write("\tCongratulation! You are winning $10 prize!");
                        
                        break;
                    case 4:
                        Win = true;
                        foreach (var item in lottoresult)
                        {
                            Console.Write(" " + item.ToString("D2") + " ");
                        }
                        Console.Write("\tCongratulation! You are winning 9% of the 30million!");
                        
                        break;
                    case 5:
                        Win = true;
                        if (quickpicklist.LottoLists[i].GetResultList().Contains(winninglist.GetBonusNumber()))
                        {
                            foreach (var item in lottoresult)
                            {
                                Console.Write(" " + item.ToString("D2") + " ");
                            }
                            Console.Write("+ " + winninglist.GetBonusNumber());
                            Console.Write("\tCongratulation! You are winning 57.5 % of the 30million!");
                            
                        }
                        else
                        {
                            foreach (var item in lottoresult)
                            {
                                Console.Write(" " + item.ToString("D2") + " ");
                            }
                            Console.Write("\tCongratulation! You are winning 47.5 % of the 30million!");
                        }
                        break;
                    case 6:
                        Win = true;
                        foreach (var item in lottoresult)
                        {
                            Console.Write(" " + item.ToString("D2") + " ");
                        }
                        Console.Write("\tCongratulations! You are winning 80.5 % of the 30million!");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
            if (Win)
            {
                Console.Write("\nCongratulations! You win in this lottery!");
            }
            else
                Console.Write("\nSorry, you lose this time.");

            Console.Write("\n\nDo you want to try again ( Y/N ) ? ");
            Again = Console.ReadLine();
            Console.Write("\n");
            } while (Again == "y"|| Again == "Y");
        }

        public static List<int> GetLottoResult(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();
            foreach (var item in list1)
            {
                if (list2.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}
