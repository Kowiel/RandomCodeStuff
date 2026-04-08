using System.Diagnostics.Metrics;

namespace RandomCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string []strs = { "bat", "bag", "bank", "band" };
            int []nums = { 1, 2, 3, 4 , 2};

            var awnser = hasDuplicate(nums);
            Console.WriteLine(awnser);
        }

        #region Stuff

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return "";

            string prefix = "";

            for (int i = 0;i < strs[0].Length;i++)
            {
                for  (int j = 1;j < strs.Length;j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                        return prefix;
                }

                prefix = prefix + strs[0][i];
            }
            return prefix;

        }

        public static bool hasDuplicate(int[] nums)
        {
            var MainDictionary = new Dictionary<int,int>();
            foreach (int num in nums)
            {
                if (!MainDictionary.ContainsKey(num))
                {
                    MainDictionary.Add(num, num);
                }
                else
                    return true;
            }
            return false;

            // optional 
/* 
 *             var Dictionary = new Dictionary<int, int>();
foreach (int num in nums)
{
if(!Dictionary.TryAdd(num, 0))
{
    return true;
}
}
return false;*/

}

        public static bool IsAnagram(string s, string t)
        {
            if (s == null || t == null)
                return false;

            var DictionaryOne = new Dictionary<char,int>();
            var DictionaryTwo = new Dictionary<char,int>();
            foreach(char c in s)
            {
                if (DictionaryOne.ContainsKey(c))
                    DictionaryOne[c] +=1;
                else
                    DictionaryOne.TryAdd(c, 1);
            }
            foreach (char c in t)
            {
                if (DictionaryTwo.ContainsKey(c))
                    DictionaryTwo[c] += 1;
                else
                    DictionaryTwo.TryAdd(c, 1);
            }
            bool areEqual = DictionaryOne.OrderBy(kv => kv.Key).SequenceEqual(DictionaryTwo.OrderBy(kv => kv.Key));
            return areEqual;
        }

        public static  bool IsValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
            Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
            Dictionary<string, HashSet<char>> squares = new Dictionary<string, HashSet<char>>();

            for (int r = 0; r < 9 ; r++)
            {
                for (int c = 0; c<9;c++)
                {
                    if (board[r][c] == '.') continue;
                    string squere = (r / 3) + "," + (c / 3);

                    if ((rows.ContainsKey(r) && rows[r].Contains(board[r][c])) ||
                        (cols.ContainsKey(c) && cols[c].Contains(board[r][c])) ||
                        (squares.ContainsKey(squere) && squares[squere].Contains(board[r][c])))
                    {
                        return false;
                    }

                    if (!rows.ContainsKey(r)) rows[r] = new HashSet<char>();
                    if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                    if (!squares.ContainsKey(squere)) squares[squere] = new HashSet<char>();

                    rows[r].Add(board[r][c]);
                    cols[c].Add(board[r][c]);
                    squares[squere].Add(board[r][c]);

                }
            }
            return true;

        }


        #endregion

    }
}
