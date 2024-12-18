using System.Text.Json.Serialization;

public class GetProductResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}