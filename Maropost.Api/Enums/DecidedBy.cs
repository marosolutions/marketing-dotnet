using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maropost.Api.Enums
{
    public enum DecidedBy
    {
        [Description("TopChoice")]
        TopChoices,
        [Description("Opens")]
        HighestOpenRate,
        [Description("Clicks")]
        HighestClickRate,
        [Description("Manual")]
        ManualSelection,
        [Description("click_to_open")]
        HighestClickToOpenRate,
        [Description("conversions")]
        HighestConversionRate
    }

    public static class DecidedByExtensions
    {
        public static string ToFriendlyString(this DecidedBy me)
        {
            switch (me)
            {
                case DecidedBy.TopChoices:
                    return "TopChoice";
                case DecidedBy.HighestOpenRate:
                    return "Opens";
                case DecidedBy.HighestClickRate:
                    return "Clicks";
                case DecidedBy.ManualSelection:
                    return "Manual";
                case DecidedBy.HighestClickToOpenRate:
                    return "click_to_open";
                case DecidedBy.HighestConversionRate:
                    return "conversions";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }

}
