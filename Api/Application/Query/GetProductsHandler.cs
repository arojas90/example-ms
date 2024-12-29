using MediatR;

namespace Application.Query;

public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
{
    public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetProductsResponse
        {
            // create list of products
            products = new List<Product>
            {
                new Product
                {
                    Id = "1",
                    Name = "Product Name",
                    Description = "Product Description",
                    Price = 100
                },
                new Product
                {
                    Id = "2",
                    Name = "Product Name 2",
                    Description = "Product Description 2",
                    Price = 200
                },
            }

        });
    }
}
