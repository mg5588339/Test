namespace Test.Domain.Interfaces.Base
{
    public interface INamingEntity
    {
        string Name { get; set; }

    }
    public interface INamingWithDescriptionEntity : INamingEntity
    {
        string Description { get; set; }

    }
}
