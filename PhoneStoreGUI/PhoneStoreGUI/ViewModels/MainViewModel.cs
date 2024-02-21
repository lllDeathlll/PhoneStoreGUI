using System;
using System.Reactive.Linq;
using PhoneStoreGUI.DataModel;
using PhoneStoreGUI.Services;
using ReactiveUI;
namespace PhoneStoreGUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
    private PhoneStoreService _phoneStoreService;
    public PhoneStoreViewModel PhoneStore { get; }
    public MainViewModel()
    {
        _phoneStoreService = new PhoneStoreService();
        PhoneStore = new PhoneStoreViewModel(_phoneStoreService.GetItems());
        PhoneStore.ListItems.CollectionChanged += (obj, e) =>
        {
            PhoneStoreService.UpdateItems(PhoneStore.ListItems);
        };
        _contentViewModel = PhoneStore;
    }

    public void AddItem()
    {
        AddPhoneViewModel addPhoneViewModel = new();

        Observable.Merge(
                addPhoneViewModel.OkCommand,
                addPhoneViewModel.CancelCommand.Select(_ => (Phone?) null))
            .Take(1)
            .Subscribe(newItem =>
            {
                if (newItem != null)
                {
                    PhoneStore.ListItems.Add(newItem);
                }
                ContentViewModel = PhoneStore;
            });

        ContentViewModel = addPhoneViewModel;
    }
}