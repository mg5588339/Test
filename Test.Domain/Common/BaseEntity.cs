using Test.Domain.Interfaces.Base;

namespace Test.Domain.Common
{
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }

}
