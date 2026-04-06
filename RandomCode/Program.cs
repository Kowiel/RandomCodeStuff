namespace RandomCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string []strs = { "bat", "bag", "bank", "band" };

            var awnser = LongestCommonPrefix(strs);
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


        #endregion

    }
}
