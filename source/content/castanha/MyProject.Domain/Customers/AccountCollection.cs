namespace MyProject.Domain.Customers
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Collections;

    public class AccountCollection : IEnumerable<Guid>
    {
        private List<Guid> items;
        public IReadOnlyCollection<Guid> Items
        {
            get
            {
                return items.AsReadOnly();
            }
            private set
            {
                items = value.ToList();
            }
        }

        public AccountCollection()
        {
            items = new List<Guid>();
        }

        public AccountCollection(IEnumerable<Guid> list)
        {
            items = list.ToList();
        }

        internal void Add(Guid accountId)
        {
            items.Add(accountId);
        }

        public IEnumerator<Guid> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
