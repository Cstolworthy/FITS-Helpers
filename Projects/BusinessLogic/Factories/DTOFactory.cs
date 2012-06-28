using Castle.MicroKernel;
using Interfaces.Marker;

namespace BusinessLogic.Factories
{
    public class DtoFactory : IFactory
    {
        private IKernel _kernal;

        public DtoFactory(IKernel kernel)
        {
            _kernal = kernel;
        }

        public T Create<T>() where T : IValueObject
        {
            return (T)_kernal.Resolve(typeof (T));
        }
    }
}