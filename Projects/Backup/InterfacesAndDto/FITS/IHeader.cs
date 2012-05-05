using System;

namespace Interfaces.FITS
{
    public interface IHeader
    {
        
        Guid Id { get; set; }
        int RecordCount { get; set; }
        string Author { get; set; }
        int BitPix { get; set; }
        string BlankValue { get; set; }
        double BScale { get; set; }
        string BUnit { get; set; }
        double BZero { get; set; }
        DateTime CreationDate { get; set; }
        double Epoch { get; set; }
        double Equinox { get; set; }
        long FileOffset { get; set; }
        int GroupCount { get; set; }
        string Instrument { get; set; }
        double MaximumValue { get; set; }
        double MinimumValue { get; set; }
        string Object { get; set; }
        DateTime ObservationDate { get; set; }
        string Observer { get; set; }
        string Origin { get; set; }
        int ParameterCount { get; set; }
        string Reference { get; set; }
        bool Rewriteable { get; set; }
        long Size { get; set; }
        string Telescope { get; set; }
    }
}
