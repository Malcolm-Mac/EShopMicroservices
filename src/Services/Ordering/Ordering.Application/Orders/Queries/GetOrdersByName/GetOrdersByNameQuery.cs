namespace Ordering.Application.Orders.Queries.GetOrdersByName;
public record GetOrderByNameResult(IEnumerable<OrderDto> Orders);
public record GetOrderByNameQuery(string Name):IQuery<GetOrderByNameResult>;
