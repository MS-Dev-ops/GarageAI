namespace GarageAI.Application.Customers.Queries.GetCustomerByName;

public sealed class GetCustomerByNameQuery
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}