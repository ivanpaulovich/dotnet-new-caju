namespace Hexagonal_BasicProject.Application.Commands.Close
{
    using System;

    public class CloseCommand
    {
        public Guid AccountId { get; private set; }

        public CloseCommand(Guid guid)
        {
            AccountId = guid;
        }
    }
}
