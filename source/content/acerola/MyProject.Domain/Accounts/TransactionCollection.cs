namespace MyProject.Domain.Accounts
{
    using MyProject.Domain.ValueObjects;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionCollection : IEnumerable<Transaction>
    {
        private List<Transaction> items;
        public IReadOnlyCollection<Transaction> Items
        {
            get
            {
                return items.AsReadOnly();
            }
            protected set
            {
                items = value.ToList();
            }
        }

        public TransactionCollection()
        {
            items = new List<Transaction>();
        }

        public TransactionCollection(IEnumerable<Transaction> list)
        {
            items = list.ToList();
        }

        internal Amount GetCurrentBalance()
        {
            Amount totalAmount = 0;

            //
            // TODO: Think on a better Strategy
            //

            foreach (var item in Items)
            {
                if (item is Debit)
                    totalAmount -= item.Amount;

                if (item is Credit)
                    totalAmount += item.Amount;
            }

            return totalAmount;
        }

        internal void Add(Transaction transaction)
        {
            items.Add(transaction);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
