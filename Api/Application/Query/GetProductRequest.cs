using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Query;

public class GetProductRequest : IRequest<GetProductResponse>
{
    [FromRoute()]
    public required int Id { get; set; }
}

