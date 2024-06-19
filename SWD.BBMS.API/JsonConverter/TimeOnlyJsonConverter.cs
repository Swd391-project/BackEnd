using System.Text.Json;
using System.Text.Json.Serialization;

namespace SWD.BBMS.API.JsonConverter
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";
        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Read the time string from the JSON
            string timeString = reader.GetString();
            return TimeOnly.ParseExact(timeString, TimeFormat);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            // Write the TimeOnly value as a string in the "HH:mm" format
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
