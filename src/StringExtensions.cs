using System.Globalization;

namespace cultured_string;

public static class StringExtensions {
    public static CulturedString AsCulturedString(this string s) {
        return new CulturedString(s);
    }
    public static CulturedString AsCulturedString(this string s, CultureInfo cultureInfo) {
        return new CulturedString(s, cultureInfo);
    }
}