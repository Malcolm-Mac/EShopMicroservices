namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string Username);
public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{Username}", async (string Username, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(Username));
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("GetBasketByUsername")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Basket By Username")
        .WithDescription("Get Basket By Username");
    }
}
