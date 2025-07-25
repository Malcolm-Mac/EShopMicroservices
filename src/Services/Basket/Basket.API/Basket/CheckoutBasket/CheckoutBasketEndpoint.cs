﻿namespace Basket.API.Basket.CheckoutBasket;
public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
public record CheckoutResponse(bool IsSucess);
public class CheckoutBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<CheckoutBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CheckoutResponse>();
            return Results.Ok(response);
        })
        .WithName("CheckoutBasket")
        .Produces<CheckoutResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Checkout Basket")
        .WithDescription("Checkout Basket");
    }
}
