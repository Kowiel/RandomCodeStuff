using System.Diagnostics.Metrics;

namespace RandomCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string []strs = { "bat", "bag", "bank", "band" };
            int []nums = { 1, -1, -1, 0 };
            string Teststring = "Was it a car or a cat I saw?";

            var awnser = ThreeSum(nums);
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

        public static bool IsPalindrome(string s)
        {
            int Start = 0;
            int End = s.Length - 1;
            while (Start < End)
            {
                while (Start < End && !char.IsLetterOrDigit(s[Start]))
                {
                    Start++; 
                }
                while (Start < End && !char.IsLetterOrDigit(s[End]))
                {
                    End--;
                }
                char left = char.ToLowerInvariant(s[Start]);
                char right = char.ToLowerInvariant(s[End]);

                if (left != right)
                    return false;

                Start++;
                End--;
            }
            return true;
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left]+numbers[right];

                if (sum > target)
                    right--;
                if (sum < target)
                    left++;
                if (sum == target)
                   return new int[] { left+1, right+1 };
            }
            return new int[] { 0, 0 };
        }

        public static int MaxArea(int[] heights)
        {
            int left = 0;
            int right = heights.Length - 1;
            int maxArea = 0;
            while (left < right)
            {
                int area = 0;
                if (heights[left] > heights[right])
                {
                    area = heights[right] * (right - left);
                    right--;
                }
                else if (heights[left] <= heights[right])
                {
                    area = heights[left] * ( right - left);
                    left++;
                }
                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }

        public static int MaxAreax(int[] heights)
        {
            int left = 0;
            int right = heights.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int width = right - left;
                int height = Math.Min(heights[left], heights[right]);

                int area = width * height;

                if (area > maxArea)
                    maxArea = area;

                if (heights[left] < heights[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }

        public static List<List<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> res = new List<List<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum > 0)
                    {
                        right--;
                    }
                    else if (sum<0)
                        left++;
                    else
                    {
                        res.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        right--;
                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                    }
                }
            }
            return res;

        }
            #endregion

        }
}
