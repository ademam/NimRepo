using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimClient.Utility
{
    internal static class GameManager
    {
       public static bool IsVictory(INimRow[] rows)
        {
            if ((from row in rows
                 select row.TokenCount).Sum() == 1) return true;
            return false;
        }
    }
}
