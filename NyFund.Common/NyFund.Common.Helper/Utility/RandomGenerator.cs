using System.Text;

namespace NyFund.Common.Helper.Utility
{
    public class RandomGenerator
    {
        private readonly Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var @char = (char)this.random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public string RandomPassword(int length)
        {
            int numericLegth = Convert.ToInt32(length / 2);
            int minValue = (int)Math.Pow(10, (double)numericLegth);

            var passwordBuilder = new StringBuilder();

            passwordBuilder.Append(this.RandomString(length - numericLegth, true));

            passwordBuilder.Append(this.RandomNumber(minValue, (minValue * 10) - 1));

            return passwordBuilder.ToString();
        }
    }
}
