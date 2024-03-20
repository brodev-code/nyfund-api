using NyFund.Common.Helper.Utility;

namespace NyFund.Common.Helper.Helper
{
    public static class OtpHelper
    {
        public static string Create(bool isAlphanumeric, int length)
        {
            string result = string.Empty;

            RandomGenerator random = new RandomGenerator();

            if (!isAlphanumeric)
            {
                double minValue = Math.Pow(10, (double)length - 1);
                result = random.RandomNumber((int)minValue, (((int)minValue) * 10) - 1).ToString();
            }
            else
            {
                result = random.RandomPassword(length);
            }

            return result;
        }

        public static string CreateStringCode(int size, bool lowerCase = false)
        {
            RandomGenerator random = new RandomGenerator();
            string result = random.RandomString(size, lowerCase);

            return result;
        }
    }
}
