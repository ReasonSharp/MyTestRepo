using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyListView {
 class MainViewModel : INotifyPropertyChanged {

  public event PropertyChangedEventHandler PropertyChanged;
  protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
   if (PropertyChanged != null)
    PropertyChanged(sender, e);
  }

  private MyObject mySelectedLocation;
  public MyObject MySelectedLocation {
   get { return mySelectedLocation; } set {
    mySelectedLocation = value;
    OnPropertyChanged(this, new PropertyChangedEventArgs("MySelectedLocation"));
   }
  }

  public ObservableCollection<MyObject> SillyStuff {
   get; set;
  }

  public MainViewModel() {
   var cvm1 = new MyObject();
   cvm1.ID = 12345;

   var cvm2 = new MyObject();
   cvm2.ID = 54321;

   var cvm3 = new MyObject();
   cvm3.ID = 15243;

   SillyStuff = new ObservableCollection<MyObject>();
   SillyStuff.Add(cvm1);
   SillyStuff.Add(cvm2);
   SillyStuff.Add(cvm3);
  }
 }
}