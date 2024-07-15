using SWD.BBMS.Services.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SWD.BBMS.Services.JsonConverters
{
    public class BookingStatusJsonConverter : JsonConverter<BookingModelStatus>
    {
        public override BookingModelStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string enumString = reader.GetString();
            return enumString switch
            {
                "Confirmed" => BookingModelStatus.Confirmed,
                "InProgress" => BookingModelStatus.InProgress,
                "Completed" => BookingModelStatus.Completed,
                "Cancelled" => BookingModelStatus.Cancelled,
                "Expired" => BookingModelStatus.Expired,
                "Deleted" => BookingModelStatus.Deleted,
                _ => throw new ArgumentException("Invalid booking status value")
            };
        }

        public override void Write(Utf8JsonWriter writer, BookingModelStatus value, JsonSerializerOptions options)
        {
            string enumString = value switch
            {
                BookingModelStatus.Confirmed => "Confirmed",
                BookingModelStatus.InProgress => "InProgress",
                BookingModelStatus.Completed => "Completed",
                BookingModelStatus.Cancelled => "Cancelled",
                BookingModelStatus.Expired => "Expired",
                BookingModelStatus.Deleted => "Deleted",
                _ => throw new ArgumentException("Invalid booking status value")
            };
            writer.WriteStringValue(enumString);
        }
    }
}
