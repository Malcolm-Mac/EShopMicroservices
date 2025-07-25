﻿namespace Shopping.Web.Models.Ordering;
public record OrderModel
(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    AddressDto ShippingAddress,
    AddressDto BillingAddress,
    PaymentDto Payment,
    OrderStatus Status,
    List<OrderItemDto> OrderItems
);
public record AddressDto
(
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string State,
    string ZipCode
);
public record PaymentDto
(
    string CardName,
    string CardNumber,
    string Expiration,
    string Cvv,
    int PaymentMethod
);
public enum OrderStatus
{
    Unspecified = -1,
    Draft = 0,
    Pending = 1,
    Completed = 2,
    Cancelled = 3
}
public record OrderItemDto
(
    Guid OrderId,
    Guid ProductId,
    int Quantity,
    decimal Price
);
public record CreateOrderRequest(OrderModel Order);
public record CreateOrderResponse(Guid Id);
public record DeleteOrderResponse(bool IsSuccess);
public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);
public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);
public record GetOrdersByCustomerResponse(IEnumerable<OrderModel> Orders);
