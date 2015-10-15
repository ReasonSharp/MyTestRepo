using System.Windows;
using Microsoft.Practices.Unity;

namespace MyListView {
 public partial class MainWindow : Window {
  private MainViewModel vm;

  public MainWindow() {
   InitializeComponent();
  }

  [Dependency]
  internal MainViewModel VM {
   set {
    this.vm = value;
    this.DataContext = vm;
   }
  }
 }
}
