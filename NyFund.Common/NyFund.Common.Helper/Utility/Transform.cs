namespace NyFund.Common.Helper.Utility
{
    public static class Transform
    {
        public static string ToRegexSearchText(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var groupAlpha = new[] {
                "[iİıI]",
                "[gGğĞ]",
                "[üÜuU]",
                "[çÇcC]",
                "[şŞsS]",
                "[öÖoO]"
            };

            input = input.ToLower();
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Distinct();
            words = words.Select(x => $"(.*({string.Concat(x.Select(c => groupAlpha.FirstOrDefault(d => d.Contains(c)) ?? c.AddsPrefixForSingleCharacters()))}))");
            input = string.Concat(words);
            return $"({input})";
        }

        public static string ToRegexEqualText(this string input, int startIndex = 0)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var groupAlpha = new[] {
                "[aA]",
                "[bB]",
                "[cC]",
                "[çÇ]",
                "[dD]",
                "[eE]",
                "[fF]",
                "[gG]",
                "[ğĞ]",
                "[hH]",
                "[İ]",
                "[I]",
                "[jJ]",
                "[kK]",
                "[lL]",
                "[mM]",
                "[nN]",
                "[oO]",
                "[öÖ]",
                "[pP]",
                "[rR]",
                "[sS]",
                "[şŞ]",
                "[tT]",
                "[uU]",
                "[üÜ]",
                "[vV]",
                "[yY]",
                "[zZ]",
                "[xX]",
                "[wW]",
                "[qQ]"
            };
            input = string.Concat(input.Select(x => groupAlpha.FirstOrDefault(alpha => alpha.Contains(x)) ?? x.AddsPrefixForSingleCharacters()));
            input = $@"^{new string('.', startIndex)}{input}$";
            return input;
        }

        private static string AddsPrefixForSingleCharacters(this char input)
        {
            return char.IsLetterOrDigit(input) || char.IsWhiteSpace(input) ? input.ToString() : @"\" + input.ToString();
        }
    }
}