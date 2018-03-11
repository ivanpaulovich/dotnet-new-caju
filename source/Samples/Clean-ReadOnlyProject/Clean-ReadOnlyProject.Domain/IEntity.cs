namespace Clean_ReadOnlyProject.Domain
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }
    }
}
