using System.Globalization;
using Microsoft.Net.Http.Headers;

namespace Application.Commons.Resources;

public static class SupportedCulture
{
    private static readonly List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new("en-US"),
        new("ru-RU"),
        new("pl-PL"),
        new("et-EE")
    };

    public static List<CultureInfo> GetSupportedCultures()
    {
        return supportedCultures;
    }

    public static string GetCorrectAcceptLanguage(IList<StringWithQualityHeaderValue> headerValues)
    {
        var headerValue = headerValues.FirstOrDefault();

        string acceptLanguage = headerValue?.Value.Buffer;

        var supportedCultureList = supportedCultures.Select(c => c.Name).ToList();

        if (supportedCultureList.Contains(acceptLanguage))
            return acceptLanguage;

        return supportedCultureList.FirstOrDefault();
    }
}
