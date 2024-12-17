namespace Ordering.Domain.Enums;

public enum OrderStatus
{
    Unspecified = -1,
    Draft = 0,
    Pending = 1,
    Completed = 2,
    Cancelled = 3
}
