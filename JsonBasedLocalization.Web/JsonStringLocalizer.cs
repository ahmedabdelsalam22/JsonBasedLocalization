using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace JsonBasedLocalization.Web
{
    public class JsonStringLocalizer : IStringLocalizer
    {

        private readonly JsonSerializer _serializer = new JsonSerializer();


        public LocalizedString this[string name] 
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value);
            }
        }

        public LocalizedString this[string name, params object[] arguments] 
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments))
                    : actualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        private string GetString(string key) 
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullFilePath = Path.GetFullPath(filePath);

            if (File.Exists(fullFilePath)) 
            {
                var result = GetValueFromJson(key, fullFilePath);
                return result;
            }
            return string.Empty;
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

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName && reader.Value as string == propertyName)
                {
                    reader.Read();
                    return _serializer.Deserialize<string>(reader);

                }
            }

            return string.Empty;
        }
    }
}
