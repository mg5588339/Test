namespace Test.Domain.Interfaces.Base
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
