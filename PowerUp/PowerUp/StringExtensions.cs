namespace PowerUp
{
    public static class StringExtensions
    {
        public static bool IsInteger(this string s)
        {
            int output;
            return int.TryParse(s, out output);
        }

        public static string Format(this string s, object arg0) =>
            string.Format(s, arg0);

        public static string Format(this string s, object arg0, object arg1) =>
            string.Format(s, arg0, arg1);

        public static string Format(this string s, object arg0, object arg1, object arg2) =>
            string.Format(s, arg0, arg1, arg2);

        public static string Format(this string s, params object[] args) =>
            string.Format(s, args);
    }
}