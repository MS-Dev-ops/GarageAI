namespace GarageAI.Application.AI.Features.Customers;

public enum CustomerFeatureIntent
{
    Unknown,

    CustomerCount,

    ListCustomers,

    ListActiveCustomers,

    FindCustomerByName,

    FindCustomerByPhone,

    FindCustomerByEmail,

    CustomerDetails
}