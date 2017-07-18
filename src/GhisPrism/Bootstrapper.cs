namespace GhisPrism
{
  using Prism.Modularity;
  using Prism.Unity;
  using Microsoft.Practices.Unity;
  using System.Windows;
  using Views;

  public class Bootstrapper : UnityBootstrapper
  {
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