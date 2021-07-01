namespace Test.Domain.Interfaces.Base
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
    }
}
