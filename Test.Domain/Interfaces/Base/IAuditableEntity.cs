using System;

namespace Test.Domain.Interfaces.Base
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime Created { get; set; }
        string LastModifiedBy { get; set; }
        DateTime? LastModified { get; set; }
    }
}
