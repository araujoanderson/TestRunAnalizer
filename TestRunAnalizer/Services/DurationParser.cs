using System.Xml;
using TestRunAnalizer.Interfaces;

namespace TestRunAnalizer.Services
{
    public class DurationParser : IDurationParser
    {
        public TimeSpan ParseDuration(string duration)
        {
            if (string.IsNullOrWhiteSpace(duration))
            {
                throw new ArgumentException("Duration string cannot be null or empty", nameof(duration));
            }

            try
            {
                // Parsing the duration string to a TimeSpan object if possible
                return XmlConvert.ToTimeSpan(duration);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException($"Invalid duration format: {duration}, cannot parse it", ex);
            }
        }
    }
}
