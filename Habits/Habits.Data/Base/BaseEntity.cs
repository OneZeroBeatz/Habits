using System;

namespace Habits.Data.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
