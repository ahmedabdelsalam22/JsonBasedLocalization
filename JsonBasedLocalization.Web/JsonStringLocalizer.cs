﻿using Microsoft.Extensions.Localization;

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
    }
}