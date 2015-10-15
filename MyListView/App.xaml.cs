using System.Windows;
using Microsoft.Practices.Unity;

namespace MyListView {
 /// <summary>
 /// Interaction logic for App.xaml
 /// </summary>
 public partial class App : Application {
  protected override void OnStartup(StartupEventArgs e) {
   base.OnStartup(e);

   UnityContainer container = new UnityContainer();
   var mainView = container.Resolve<MainWindow>();
   container.Dispose();
   mainView.Show();
  }
 }
}
