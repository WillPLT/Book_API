using System.Text.Json.Serialization;

namespace Book_API.Models
{
   [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenreBookClass
    {
        SciFi,
        Comedy,
        Crime,
        Horror,
        Fantasy,
        History,
        Technical

    }
}
