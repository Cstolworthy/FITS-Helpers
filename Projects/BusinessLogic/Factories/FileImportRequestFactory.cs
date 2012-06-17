using System;
using Castle.MicroKernel;
using Interfaces.DTO;
using Interfaces.Marker;

namespace BusinessLogic.Factories
{
    public class FileImportRequestFactory : IFactory
    {
        private IKernel _kernel;

        public FileImportRequestFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IFileImportRequest Create(string raColumn, string decColumn)
        {
            var obj = _kernel.Resolve<IFileImportRequest>();

            obj.RaColumn = raColumn;

            obj.DecColumn = decColumn;

            obj.FoundOn = DateTime.UtcNow;

            return obj;
        }
    }
}
