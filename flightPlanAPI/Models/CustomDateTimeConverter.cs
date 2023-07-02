using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlightPlanAPI.Models
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
		public DateFormatConverter(string format)
		{
			DateTimeFormat = format;
		}
	}

    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture));

        }
    }
}
