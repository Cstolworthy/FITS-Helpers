using System.Collections.Generic;

namespace Interfaces.FITS
{
    public interface IFitsHandler
    {
        List<string> Columns { get; }
    }
}
