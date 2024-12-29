using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Query;
public class GetProductsRequest : IRequest<GetProductsResponse>
{
  [FromRoute()]
  public string? Id { get; set;}
}
