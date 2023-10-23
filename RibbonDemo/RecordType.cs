using System.ComponentModel;

namespace RibbonDemo
{
    public enum RecordType
    {
        [Description("All Events")]
        All,
        [Description("Future Events")]
        Future,
        [Description("Past Events")]
        Past
    }
}