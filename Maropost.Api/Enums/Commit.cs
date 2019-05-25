using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maropost.Api.Enums
{
    public enum Commit
    {
        [Description("Save as Draft")]
        SaveAsDraft,
        [Description("Send Test")]
        SendTest,
        [Description("Schedule")]
        Schedule
    }

    public static class CommitOptionExtensions
    {
        public static string ToFriendlyString(this Commit me)
        {
            switch (me)
            {
                case Commit.SaveAsDraft:
                    return "Save as Draft";
                case Commit.Schedule:
                    return "Schedule";
                case Commit.SendTest:
                    return "Send Test";
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }

}
