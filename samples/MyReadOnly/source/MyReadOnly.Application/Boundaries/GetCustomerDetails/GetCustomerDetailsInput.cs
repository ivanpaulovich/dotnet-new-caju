namespace MyReadOnly.Application.Boundaries.GetCustomerDetails
{
    using System;
    using MyReadOnly.Application.Exceptions;

    public sealed class GetCustomerDetailsInput
    {
        public Guid CustomerId { get; }

        public GetCustomerDetailsInput(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new InputValidationException($"{nameof(customerId)} cannot be empty.");
            }

            CustomerId = customerId;
        }
    }
}