using System;

namespace ETG.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTimeOffset CreateOn { get; set; } = DateTimeOffset.Now;
    }
}
