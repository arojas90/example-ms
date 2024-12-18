using MediatR;

public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
{
    public Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GetProductResponse
        {
            Name = "Product 1"
        });
    }
}