
namespace NyFund.Common.Helper.Utility
{
    public static class Masked
    {
        public static string MaskedGsm(string gsm)
        {
            if (!string.IsNullOrEmpty(gsm))
            {
                var start = gsm.Substring(0, 4);
                var end = gsm.Substring(gsm.Length - 2, 2);
                return start + " *** ** " + end;
            }

            return "";
        }

        public static string MaskedEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var start = email.Substring(0, 4);
                var end = email.Split('@')[1].Substring(0, 2);
                return start + "******@" + end + "*****.com";
            }

            return "";
        }

        public static string MaskedText(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            text = text.Replace(" ", "").ToUpper();

            var first = text.Substring(0, 1);
            var last = text.Substring(text.Length - 1, 1);

            for (int i = 2; i < text.Length; i++)
            {
                first += "*";
            }

            var value = first + last;
            return value;
        }
    }
}
