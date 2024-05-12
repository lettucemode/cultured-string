using System.Globalization;
using System.Text;

namespace cultured_string;

public class CulturedString(string s, CultureInfo cultureInfo) {
    private readonly string _s = s;
    private readonly CultureInfo _cultureInfo = cultureInfo;

    public CulturedString(string s): this(s, CultureInfo.InvariantCulture) {}

    public string RenderToCulture() {
        return _s.ToString(_cultureInfo);
    }

    public string RenderToCulture(CultureInfo toCulture) {
        return _s.ToString(_cultureInfo).ToString(toCulture);
    }
    
    public static CulturedString Deserialize(string s) {
        if (s.Length < 3) throw new ArgumentException("String to deserialize must be at least length 3.");
        var ci = CultureInfo.GetCultures(CultureTypes.AllCultures)
                            .FirstOrDefault(cult => cult.ThreeLetterISOLanguageName == s[..3])
                            ?? throw new ArgumentException("First three characters do not match any known culture's ISO specifier.");
        return new CulturedString(s, ci);
    }

    public string Serialize() {
        var builder = new StringBuilder(_s.Length + 3);
        builder.Append(_cultureInfo.ThreeLetterISOLanguageName);
        builder.Append(_s);
        return builder.ToString();
    }
}
