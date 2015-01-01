using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NimClient.Utility
{
    internal static class GameManager
    {
        public static bool IsVictory(INimRow[] rows)
        {
            int cnt = (from row in rows select row.TokenCount).Sum();

            if (cnt == 1) return true;
            return false;
        }

        public static void CalculateAITurn(INimRow[] rows)
        {
            int sum = CalculateNimSum(rows);
            BalanceNimTree(sum, rows);
        }

        #region Private Methods

        private static void BalanceNimTree(int sum, INimRow[] rows)
        {
            if (rows.Where(row => row.TokenCount > 0).Count() == 1) // Victory Condition; just take all but the last token.
            {
                INimRow row = rows.Where(r => r.TokenCount > 0).Single();

                while (row.TokenCount > 1)
                {
                    row.RemoveToken();
                    Thread.Sleep(500);
                }

                return;
            }
            else if (rows.Where(row => row.TokenCount > 0).Count() == 2 &&
                rows.Where(row => row.TokenCount == 1).Count() == 1) // Victory Condition; just remove all the tokens in the large row leaving a single token in the remaining row.
            {
                INimRow row = rows.Where(r => r.TokenCount > 1).Single();

                while (row.TokenCount > 0)
                {
                    row.RemoveToken();
                    Thread.Sleep(500);
                }

                return;
            }
            else if (rows.Where(row => row.TokenCount > 0).Count() == 3 &&
                rows.Where(row => row.TokenCount == 1).Count() == 2) // Victory condition; Leave 3 tokens on the board;
            {
                INimRow row = rows.Where(r => r.TokenCount > 1).Single();

                while (row.TokenCount > 1)
                {
                    row.RemoveToken();
                    Thread.Sleep(500);
                }

                return;
            }
            else CalculatePlay(sum, rows);
        }

        private static void CalculatePlay(int sum, INimRow[] rows)
        {
            if(sum == 0) //the tree is balanced, just pick a row and remove some tokens
            {
                Random rand = new Random();
                INimRow[] valrows = rows.Where(row => row.TokenCount > 0).ToArray();

                INimRow randrow = valrows[rand.Next(0, valrows.Length-1)];
                while(randrow.TokenCount > rand.Next(0, randrow.TokenCount))
                {
                    randrow.RemoveToken();
                    Thread.Sleep(500);
                }

                return;
            }
            else if(rows.Where(row => row.TokenCount >= sum).Count() > 0)
            {
                //if(rows.Where(row => row.TokenCount == sum).Count() > 0) //a row with the eaxact num of tokens to remove
                //{
                    INimRow row = rows.Where(r => r.TokenCount >= sum).First();

                    for(int i = 0; i < sum; i++)
                    {
                        row.RemoveToken();
                        Thread.Sleep(500);
                    }

                    return;
                //}
            }
            else
            {
                INimRow row = rows.Where(r => r.TokenCount == (from i in rows
                                                               select i.TokenCount).Max()).Single();

                do
                {
                    row.RemoveToken();
                    Thread.Sleep(500);
                }
                while (CalculateNimSum(rows) != 0 && row.TokenCount > 0);
            }

            return;
        }

        private static int CalculateNimSum(INimRow[] rows)
        {
            byte tot = 0x0;

            foreach(INimRow row in rows)
            {
                if(row.TokenCount > 0)
                {
                    tot = (byte)(tot ^ (byte)row.TokenCount);
                }
            }

            return tot;
        }

        #endregion
    }
}
