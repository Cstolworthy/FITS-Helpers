using System;
using System.ComponentModel;
using FitsReader;
using Microsoft.Practices.Prism.Commands;

namespace UiComponents.PresentationModels
{
    public class FitsImporterViewPresentationModel : INotifyPropertyChanged
    {
        private string _selectedFile;
        public string SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;
                InvokePropertyChanged("SelectedFile");
                FileSelected = true;
            }
        }

        private bool _fileSelected;
        public bool FileSelected
        {
            get { return _fileSelected; }
            set
            {
                _fileSelected = value;
                InvokePropertyChanged("FileSelected");
            }
        }

        public bool ContainsImage
        {
            get { return _importer == null ? false : _importer.ContainsImage; }
        }

        public bool ContainsData
        {
            get { return _importer == null ? false : _importer.ContainsData; }
        }

        public bool ImportData { get; set; }
        public bool ImportImage { get; set; }

        public string DataName { get; set; }
        public string ImageName { get; set; }

        private FitsImporter _importer;

        public DelegateCommand<object> SelectFileCommand { get; private set; }
        public DelegateCommand<object> ImportFitsFileCommand { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public FitsImporterViewPresentationModel()
        {
            SelectFileCommand = new DelegateCommand<object>(SelectFile);
            ImportFitsFileCommand = new DelegateCommand<object>(ImportFitsFile);
        }

        private void ImportFitsFile(object obj)
        {
            _importer = new FitsImporter(SelectedFile);

            if (ImportImage)
                _importer.ImportFitsImage(ImageName);
            if(ImportData)
                _importer.ImportFitsData(DataName);
        }

        private void SelectFile(object obj)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".fits";
            dlg.Filter = "Fits Files (.fits)|*.fits";

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                SelectedFile = filename;
                GetFitsData();
            }
        }

        private void GetFitsData()
        {
            _importer = new FitsImporter(SelectedFile);
            InvokePropertyChanged("ContainsImage");
            InvokePropertyChanged("ContainsData");
        }
    }
}
