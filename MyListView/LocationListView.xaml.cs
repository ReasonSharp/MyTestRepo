using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace MyListView {
 public partial class LocationListView : UserControl {
  #region Dependency Properties
  public IEnumerable Locations {
   get { return (IEnumerable)GetValue(LocationsProperty); }
   set { SetValue(LocationsProperty, value); }
  }
  public static readonly DependencyProperty LocationsProperty =
  DependencyProperty.Register("Locations", typeof(IEnumerable), typeof(LocationListView), new PropertyMetadata(null, LocationsChanged));

  public MyObject SelectedLocation {
   get { return (MyObject)GetValue(SelectedLocationProperty); }
   set { SetValue(SelectedLocationProperty, value); }
  }
  public static readonly DependencyProperty SelectedLocationProperty =
  DependencyProperty.Register("SelectedLocation", typeof(MyObject), typeof(LocationListView), new PropertyMetadata(null));
  #endregion

  private static void LocationsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) {
   ((LocationListView)o).RegenerateLocations();
   if (((LocationListView)o).Locations is ObservableCollection<MyObject>) {
    var l = ((LocationListView)o).Locations as ObservableCollection<MyObject>;
    l.CollectionChanged += ((LocationListView)o).L_CollectionChanged;
   }
  }

  private void L_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
   RegenerateLocations();
  }

  private Button selectedLV = null;

  public LocationListView() {
   InitializeComponent();
  }

  private void RegenerateLocations() {
   if (Locations != null) {
    myStackPanel.Children.Clear();
    foreach (var l in Locations) {
     var b = new Button();
     b.Content = l;
     b.Click += B_Click;
     myStackPanel.Children.Add(b);
    }
   }
   selectedLV = null;
  }

  private void B_Click(object sender, RoutedEventArgs e) {
   var lv = (sender as Button)?.Content as MyObject;
   if (selectedLV != null) {
    lv.IsSelected = false;
    if ((selectedLV.Content as MyObject) == SelectedLocation) {
     SelectedLocation = null;
     selectedLV = null;
    }
   }
   if (lv != null) {
    SelectedLocation = lv;
    selectedLV = sender as Button;
    lv.IsSelected = true;
   }
  }
 }
}