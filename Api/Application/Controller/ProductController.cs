using Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/products")]
[ApiController]
[Tags("Products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public Task<GetProductResponse> GetProductById([FromRoute] int id)
    {
        var request = new GetProductRequest { Id = id };
        return _mediator.Send(request);
    }

    [HttpGet]
    public Task<GetProductsResponse> GetProducts() => _mediator.Send(new GetProductsRequest());
}

