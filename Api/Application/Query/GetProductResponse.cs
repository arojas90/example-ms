using System.Text.Json.Serialization;

namespace Application.Query;
public class GetProductResponse
{
    [JsonPropertyName("product")]
    public required Product product { get; set; }
}