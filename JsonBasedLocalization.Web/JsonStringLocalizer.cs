using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace JsonBasedLocalization.Web
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        public LocalizedString this[string name] => throw new NotImplementedException();

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        private String GetValueFromJson(String propertyName, String filePath) 
        {
            if (String.IsNullOrEmpty(propertyName) || String.IsNullOrEmpty(filePath)) 
            {
                return String.Empty;
            }

            using FileStream stream = new FileStream(filePath,FileMode.Open , FileAccess.Read , FileShare.Read);
            StreamReader streamReader = new StreamReader(stream);
            using JsonTextReader reader = new JsonTextReader(streamReader);
        }
    }
}
