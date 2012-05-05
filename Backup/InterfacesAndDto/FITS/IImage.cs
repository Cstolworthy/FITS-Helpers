using System;

namespace Interfaces.FITS
{
    public interface IImage
    {
        Guid Id { get; set; }

        string Path { get; set; }

        double MinimumRa { get; set; }
        double MaximumRa { get; set; }
        double MinimumDec { get; set; }
        double MaximumDec { get; set; }

        DateTime GeneratedOn { get; set; }
    }
}
