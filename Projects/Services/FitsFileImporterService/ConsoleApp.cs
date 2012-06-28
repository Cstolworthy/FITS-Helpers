using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.DTO;
using Interfaces.FITS;
using Interfaces.Services;

namespace FitsFileImporterService
{
    public class ConsoleApp : IConsoleApplication
    {
        private IFitsContext _context;
        private readonly IFitsFileImporter _importer;

        public ConsoleApp(IFitsContext context, IFitsFileImporter importer)
        {
            DateTime start = DateTime.Now;
            try
            {



                _context = context;
                _importer = importer;

                var waitingImports = _context.GetImportRequests();

                foreach (var fileImportRequest in waitingImports)
                {
                    ImportFile(fileImportRequest);
                }
            }
            catch(Exception e)
            {
                
            }
            DateTime end = DateTime.Now;

            var elapsed = end.Subtract(start);

            Console.Read();
        }

        private void ImportFile(IFileImportRequest fileImportRequest)
        {
            _importer.ProcessIndividualFile(fileImportRequest);
        }
    }
}
