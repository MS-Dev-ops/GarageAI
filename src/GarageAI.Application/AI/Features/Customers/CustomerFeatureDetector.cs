using System.Text.RegularExpressions;

namespace GarageAI.Application.AI.Features.Customers;

public static class CustomerFeatureDetector
{
    public static CustomerFeatureRequest Detect(string prompt)
    {
        var request = new CustomerFeatureRequest();

        prompt = prompt.Trim();

        var lower = prompt.ToLowerInvariant();

        // Customer Count
        if ((lower.Contains("how many") ||
             lower.Contains("count")) &&
            lower.Contains("customer"))
        {
            request.Intent = CustomerFeatureIntent.CustomerCount;
            return request;
        }

        // List Customers
        if ((lower.Contains("show") ||
             lower.Contains("list")) &&
            lower.Contains("customer") &&
            !lower.Contains("active"))
        {
            request.Intent = CustomerFeatureIntent.ListCustomers;
            return request;
        }

        // Active Customers
        if (lower.Contains("active") &&
            lower.Contains("customer"))
        {
            request.Intent = CustomerFeatureIntent.ListActiveCustomers;
            return request;
        }

        // Find by Email
        if (lower.Contains("email"))
        {
            request.Intent = CustomerFeatureIntent.FindCustomerByEmail;

            var email = Regex.Match(
                prompt,
                @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}");

            if (email.Success)
                request.Email = email.Value;

            return request;
        }

        // Find by Phone
        if (lower.Contains("phone"))
        {
            request.Intent = CustomerFeatureIntent.FindCustomerByPhone;

            var phone = Regex.Match(prompt, @"\d+");

            if (phone.Success)
                request.Phone = phone.Value;

            return request;
        }

        // Find by Name
        if (lower.StartsWith("find customer"))
        {
            request.Intent = CustomerFeatureIntent.FindCustomerByName;

            request.Name = prompt
                .Replace("Find customer", "", StringComparison.OrdinalIgnoreCase)
                .Trim();

            return request;
        }

        // Customer Details
        if (lower.StartsWith("who is"))
        {
            request.Intent = CustomerFeatureIntent.CustomerDetails;

            request.Name = prompt
                .Replace("Who is", "", StringComparison.OrdinalIgnoreCase)
                .Trim();

            return request;
        }

        request.Intent = CustomerFeatureIntent.Unknown;

        return request;
    }
}