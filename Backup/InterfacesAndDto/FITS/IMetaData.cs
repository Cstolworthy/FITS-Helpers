using System;
using System.Collections.Generic;

namespace Interfaces.FITS
{
    public interface IMetaData
    {
        Guid Id { get; set; }
        string RaColumnName { get; set; }
        string DecColumnName { get; set; }
        Dictionary<string, string> ColorMapping { get; set; }
        string Delimiter { get; set; }
    }
}
