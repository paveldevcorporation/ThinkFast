using System.Globalization;

namespace ThinkFast.Resources
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}