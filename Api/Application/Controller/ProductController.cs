using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/products")]
    [ApiController]
    [Tags("Products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public Task<GetProductResponse> GetProductById([FromRoute] GetProductRequest request) => _mediator.Send(request);
    }
}
