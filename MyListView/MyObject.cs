using System.Windows;

namespace MyListView {
 public class MyObject : DependencyObject {
  public int ID {
   get { return (int)GetValue(IDProperty); }
   set { SetValue(IDProperty, value); }
  }
  public static readonly DependencyProperty IDProperty =
      DependencyProperty.Register("ID", typeof(int), typeof(MyObject), new PropertyMetadata(0));
  
  public bool IsSelected {
   get; set;
  }

  public override string ToString() {
   return ID.ToString();
  }
 }
}
