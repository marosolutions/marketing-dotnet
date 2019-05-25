using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maropost.Api.Enums
{
    public enum Language
    {
        [Description("en")]
        English,
        [Description("es")]
        Spanish,
        [Description("de")]
        German,
        [Description("it")]
        Italian,
        [Description("fr")]
        French,
        [Description("pt")]
        Portguese,
        [Description("pl")]
        Polish,
        [Description("da")]
        Danish,
        [Description("zh")]
        Chinese,
        [Description("nl")]
        Dutch,
        [Description("sv")]
        Swedish,
        [Description("no")]
        Norwegian
    }

    public static class LanguageExtensions
    {
        public static string ToAbbreviation(this Language me)
        {
            switch (me)
            {
                case Language.English:
                    return "en";
                case Language.Spanish:
                    return "es";
                case Language.German:
                    return "de";
                case Language.Italian:
                    return "it";
                case Language.French:
                    return "fr";
                case Language.Portguese:
                    return "pt";
                case Language.Polish:
                    return "pl";
                case Language.Danish:
                    return "da";
                case Language.Chinese:
                    return "zh";
                case Language.Dutch:
                    return "nl";
                case Language.Swedish:
                    return "sv";
                case Language.Norwegian:
                    return "no";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }

}
