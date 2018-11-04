using Unity;

namespace CMS.Services.Factories
{
    public abstract class BaseFactory<T>
    {
        internal IUnityContainer Container { get; private set; }

        public T InstatiateService()
        {
            return InstatiateService(new UnityContainer());
        }

        public T InstatiateService(IUnityContainer container)
        {
            if (container == null)
                container = new UnityContainer();

            Container = container;
            RegisterInterfaces();
            return Container.Resolve<T>();
        }

        internal abstract void RegisterInterfaces();
    }
}
