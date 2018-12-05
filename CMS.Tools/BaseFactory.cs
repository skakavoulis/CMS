using Unity;

namespace CMS.Tools
{
    public abstract class BaseFactory<T>
    {
        protected IUnityContainer Container { get; private set; }

        public T InstatiateService()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
                RegisterInterfaces();
            }

            return Container.Resolve<T>();
        }

        public T InstatiateService(IUnityContainer container)
        {
            if (container == null)
                container = Container ?? new UnityContainer();

            Container = container;
            RegisterInterfaces();
            return Container.Resolve<T>();
        }

        public abstract void RegisterInterfaces();
    }
}
