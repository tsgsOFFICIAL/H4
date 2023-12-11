namespace HillBilly_API.Models
{
    public class LogHistory
    {
        public long id { get; private set; }
        public double outsideTemperature { get; private set; }
        public int uvIndex { get; private set; }
        public int waterLevelPercentage { get; private set; }
        public DateTime logTime { get; private set; }
        public int stableId { get; private set; }
    }
}
