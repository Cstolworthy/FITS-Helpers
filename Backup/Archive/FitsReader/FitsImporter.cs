using System;
using InterfacesAndDTO.Interfaces.Fits;
using Repositories;

namespace FitsReader
{
    public class FitsImporter : IFitsImporter
    {
        private readonly string _selectedFile;
        private readonly FitsReader _reader;

        public bool ContainsImage
        {
            get
            {
                return _reader.GetFitsImageData(_selectedFile) != null;
            }
        }

        public bool ContainsData
        { get { return false; } }

        public FitsImporter(string selectedFile)
        {
            _selectedFile = selectedFile;
            _reader = new FitsReader();
        }

        public void ImportFitsImage(string imageName)
        {
            var data = _reader.GetFitsImageData(_selectedFile);

            FitsImageRepository fir = new FitsImageRepository();
            fir.InsertImageData(imageName, data);
        }

        public void ImportFitsData(string dataName)
        {
            
        }
    }
}
