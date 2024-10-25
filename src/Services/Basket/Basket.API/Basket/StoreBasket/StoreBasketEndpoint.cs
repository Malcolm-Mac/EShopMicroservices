﻿
namespace Basket.API.StoreBasket;
public record StoreBasketRequest(ShoppingCart Cart);
public record StoreBasketResponse(string Username);
public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();
            return Results.Created($"/basket/{response.Username}", response);
        })
        .WithName("StoreBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Basket")
        .WithDescription("Store Basket");
    }
}
