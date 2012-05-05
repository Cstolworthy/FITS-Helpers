using System.Collections.Generic;

namespace Interfaces.Website.Model
{
    public interface IDesignateModel
    {
        string SelectedFile { get; set; }
        List<string> GetColumnNames();
    }
}
