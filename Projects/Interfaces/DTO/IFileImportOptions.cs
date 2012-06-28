using Interfaces.Marker;

namespace Interfaces.DTO
{
    public interface IFileImportOptions : IValueObject
    {
        string FilePath { get; set; }
    }
}
