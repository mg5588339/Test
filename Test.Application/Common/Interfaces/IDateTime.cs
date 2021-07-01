using System;

namespace Test.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
        string ToLongDateShamsi(DateTime value);
        DateTime ToShamsiDateTime(DateTime value);
        string NowName { get; }        
    }
}
