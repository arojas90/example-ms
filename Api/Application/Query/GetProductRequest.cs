using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class GetProductRequest: IRequest<GetProductResponse>
{
    [FromRoute()]
    public string? Id { get; set; }
}