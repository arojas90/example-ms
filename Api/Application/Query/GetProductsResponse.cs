using System.Text.Json.Serialization;

namespace Application.Query;

public class GetProductsResponse
{
    [JsonPropertyName("products")]
    public required List<Product> products { get; set; }
}
