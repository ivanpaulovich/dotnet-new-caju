namespace Clean_FullProject.Domain
{
    using System;

    public class Entity : IEntity
    {
        private Guid id = Guid.NewGuid();
        public Guid Id 
        { 
            get
            {
                return id;                
            }
            protected set
            {
                id = value;
            }
        }
    }
}
