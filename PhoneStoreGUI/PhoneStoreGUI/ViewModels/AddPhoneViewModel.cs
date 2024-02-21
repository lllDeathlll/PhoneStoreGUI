using System;
using System.Reactive;
using System.Reactive.Linq;
using PhoneStoreGUI.DataModel;
using ReactiveUI;

namespace PhoneStoreGUI.ViewModels;

public class AddPhoneViewModel: ViewModelBase
{
    private string _model = string.Empty;
    private int _price = 0;
    private DateTimeOffset _releaseDate = DateTime.Now;

    public ReactiveCommand<Unit, Phone> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public AddPhoneViewModel()
    {
        var isModelValid = this.WhenAnyValue(x => x.Model, x => !string.IsNullOrEmpty(x));
        var isPriceValid = this.WhenAnyValue(x => x.Price, x => x > 0);
        var isReleaseDateValid = this.WhenAnyValue(x => x.ReleaseDate, x => x != DateTime.Now);

        var isValidObservable = isModelValid.Merge(isPriceValid).Merge(isReleaseDateValid);

        OkCommand = ReactiveCommand.Create(() => new Phone(Model, Price, ReleaseDate), isValidObservable);
        CancelCommand = ReactiveCommand.Create(() => { });
    }

    public string Model { get => _model; set => this.RaiseAndSetIfChanged(ref _model, value); }
    public int Price { get => _price; set => this.RaiseAndSetIfChanged(ref _price, value); }
    public DateTimeOffset ReleaseDate { get => _releaseDate; set => this.RaiseAndSetIfChanged(ref _releaseDate, value); }
}