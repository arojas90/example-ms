using System.Diagnostics;
using MediatR;

namespace Application.Query;
public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
{
    public Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {

        return Task.FromResult(new GetProductResponse
        {
            product = new Product
            {
                Id = request.Id.ToString(),
                Name = "Product Name",
                Description = "Product Description",
                Price = 100
            }
        });
    }
}