namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>
    {
        Customer.Create(
            CustomerId.Of(new Guid("84629872-98fa-4d84-b2b3-06b949a2aac4")),
            "Malcolm",
            "malcolmprojects12@gmail.com"
            ),
        Customer.Create(
            CustomerId.Of(new Guid("57bf8467-b12e-42ad-b454-c73925ad4baa")),
            "Gareth",
            "gsekgobela28@gmail.com"
            )
    };
    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(
            ProductId.Of(new Guid("45c7fad6-ef82-4f72-99dd-749503c74f06")),
            "Iphone X",
            300),
        Product.Create(
            ProductId.Of(new Guid("f9ed99f6-e0e5-4f43-91db-24146018264a")),
            "Samsung",
            400),
        Product.Create(
            ProductId.Of(new Guid("0223c81e-af66-4cab-af85-296bf558e60f")),
            "Nokia",
            300),
        Product.Create(
            ProductId.Of(new Guid("caabe6a4-cb4d-43e8-b40a-e06b131a828d")),
            "Motorrolla",
            900)
    };
    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Malcolm", "Tsimo", "malcolmprojects12@gmail.com", "Riverside View Ext 67 Block 79", "South Africa", "Gauteng", "2189");
            var address2 = Address.Of("Gareth", "Sekgobela", "gsekgobela28@gmail.com", "Riverside View Ext 33 Block 41", "South Africa", "Gauteng", "2189");

            var payment1 = Payment.Of("Malcolm", "55555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("Malcolm", "55555555554444", "12/28", "355", 1);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("84629872-98fa-4d84-b2b3-06b949a2aac4")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of(new Guid("45c7fad6-ef82-4f72-99dd-749503c74f06")), 2, 300);
            order1.Add(ProductId.Of(new Guid("f9ed99f6-e0e5-4f43-91db-24146018264a")), 1, 400);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("57bf8467-b12e-42ad-b454-c73925ad4baa")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductId.Of(new Guid("0223c81e-af66-4cab-af85-296bf558e60f")), 2, 300);
            order2.Add(ProductId.Of(new Guid("caabe6a4-cb4d-43e8-b40a-e06b131a828d")), 1, 900);

            return new List<Order> { order1, order2 };
        }

    }
}
