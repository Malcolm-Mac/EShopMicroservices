namespace Ordering.Application.Orders.EventHandlers.Integration;
public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);
        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }
    private static CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        var addressDto = new AddressDto(message.FirstName, message.LastName, message.EmailAddress, message.AddressLine, message.Country, message.State, message.ZipCode);
        var paymentDto = new PaymentDto(message.CardName,message.CardNumber,message.Expiration, message.CVV, message.PaymentMethod);
        var OrderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: OrderId,
            CustomerId: message.CustomerId,
            OrderName: message.Username,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: OrderStatus.Pending,
            OrderItems: [
                new OrderItemDto(OrderId, new Guid("0223c81e-af66-4cab-af85-296bf558e60f"), 2, 300),
                new OrderItemDto(OrderId, new Guid("caabe6a4-cb4d-43e8-b40a-e06b131a828d"), 1, 900)
            ]
        );

        return new CreateOrderCommand(orderDto);
    }
}
