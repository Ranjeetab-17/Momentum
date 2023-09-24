namespace Converter.Helpers
{
    public static class To_Helper_Temprature
    {
        public static string ToTemprature(this decimal imperialUnit, string source, string target)
        {
            if (source == "c" && target == "f")
            {
                return $"{Math.Round(imperialUnit * 9 / 5 + 32, 4)} °{target.ToUpper()}";
            }
            else if (source == "f" && target == "c")
            {
                return $"{Math.Round((imperialUnit - 32) * 5 / 9, 4)} °{target.ToUpper()}";
            }
            else if (source == "d" && target == "k")
            {
                return $"{Math.Round((imperialUnit + 273.15m), 4)} °{target.ToUpper()}";
            }
            else if (source == "k" && target == "d")
            {
                return $"{Math.Round((imperialUnit - 273.15m), 4)} °{target.ToUpper()}";
            }

            return string.Empty;
        }
    }
}
