using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhoneStoreGUI.DataModel;

namespace PhoneStoreGUI.ViewModels;

public class PhoneStoreViewModel: ViewModelBase
{
    public ObservableCollection<Phone> ListItems { get; }

    public PhoneStoreViewModel(IEnumerable<Phone> items)
    {
        ListItems = new ObservableCollection<Phone>(items);
    }
}