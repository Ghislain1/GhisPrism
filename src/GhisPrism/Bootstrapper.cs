namespace GhisPrism
{
  using Prism.Modularity;
  using Prism.Unity;
  using Microsoft.Practices.Unity;
  using System.Windows;
  using Views;
  using Core;
  using Core.Services;

  public class Bootstrapper : UnityBootstrapper
  {
    protected override void ConfigureContainer()
    {
      base.ConfigureContainer();
      this.Container.RegisterType<IFileItemService, FileItemService>(new ContainerControlledLifetimeManager());
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new ConfigurationModuleCatalog();
    }

    protected override DependencyObject CreateShell()
    {
      return Container.Resolve<Shell>();
    }

    protected override void InitializeShell()
    {
      Application.Current.MainWindow.Show();
    }
  }
}