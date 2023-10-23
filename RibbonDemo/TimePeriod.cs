using System.ComponentModel;

namespace RibbonDemo
{
    public enum TimePeriod
    {
        [Description("Last 30 Days")]
        Last30Days,
        [Description("Last 60 Days")]
        Last60Days,
        [Description("Last 90 Days")]
        Last90Days,
        [Description("Last 180 Days")]
        Last180Days,
        [Description("Last 1 Year")]
        Last1Year,
        [Description("Last 2 Years")]
        Last2Year,
        [Description("Select a Year")]
        SelectAYear
    }
}