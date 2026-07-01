namespace GarageAI.Application.AI.Features.Customers;

public static class CustomerFeatureDetector
{
    public static CustomerFeatureIntent Detect(string prompt)
    {
        prompt = prompt.ToLowerInvariant();

        if (prompt.Contains("how many") &&
            prompt.Contains("customer"))
        {
            return CustomerFeatureIntent.CustomerCount;
        }

        if (prompt.Contains("list") &&
            prompt.Contains("customer"))
        {
            return CustomerFeatureIntent.ListCustomers;
        }

        if (prompt.Contains("find") &&
            prompt.Contains("customer"))
        {
            return CustomerFeatureIntent.FindCustomerByName;
        }

        return CustomerFeatureIntent.Unknown;
    }
}