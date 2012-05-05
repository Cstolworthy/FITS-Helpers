using System;
using InterfacesAndDto;

namespace Interfaces.FITS
{
    public interface IMapping
    {
        Guid Id { get; set; }
        IHeader Header { get; set; }
        IMetaData MetaData { get; set; }
        CollectionStatus Status { get; set; }
        long CollectionSize { get; set; }
        double LargestRa { get; set; }
        double SmallestRa { get; set; }
        double LargestDec { get; set; }
        double SmallestDec { get; set; }

    }
}
