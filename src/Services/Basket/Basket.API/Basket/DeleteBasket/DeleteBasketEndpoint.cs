﻿
namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketRequest(string Username);
public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{Username}", async (string Username, ISender sender) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(Username));
            var response = result.Adapt<DeleteBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteBasket")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Basket")
        .WithDescription("Delete Basket");
    }
}
