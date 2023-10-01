namespace Converter.Helpers
{
    public static class To_Length_Helper
    {
        public static string ToLength(this decimal imperialUnit, string target, decimal value, bool isViceVersa = false)
        {
            var output = isViceVersa ? value / imperialUnit : imperialUnit * value;

            return $"{Math.Round(output, 2)} {target.ToLower()}";
        }
    }
}
