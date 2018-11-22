using Unity;

namespace CMS.Tools
{
    public abstract class BaseFactory<T>
    {
        protected IUnityContainer Container { get; private set; }

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

        public abstract void RegisterInterfaces();
    }
}
