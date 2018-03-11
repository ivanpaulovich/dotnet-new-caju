using System;
using System.Collections.Generic;
using System.Text;

namespace Hexagonal_BasicProject.Application.Commands.Register
{
    using Hexagonal_BasicProject.Application.Results;
    public class RegisterResult
    {
        public CustomerResult Customer { get; private set; }
        public AccountResult Account { get; private set; }

        public RegisterResult()
        {

        }

        public RegisterResult(CustomerResult customer, AccountResult account)
        {
            Customer = customer;
            Account = account;
        }
    }
}
