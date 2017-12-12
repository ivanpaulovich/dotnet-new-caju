using System;

namespace Caju.Domain.Model
{
    public class Entity
    {
        private readonly DateTime date;
        private readonly float Open;
        private readonly float High;
        private readonly float Low;
        private readonly float Close;
        private readonly Int64 Volume;

        public DateTime GetDate()
        {
            return date;
        }
    }
}
