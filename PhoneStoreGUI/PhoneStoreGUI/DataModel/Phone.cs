using System;

namespace PhoneStoreGUI.DataModel;

public class Phone
{
    private DateOnly _releaseDate;

    public string Model { get; init; }
    public int Price { get; init; }
    public DateOnly ReleaseDate
    {
        get => _releaseDate;
        init
        {
            var now = DateOnly.FromDateTime(DateTime.Now);
            //var now = DateTime.Now;
            _releaseDate = value > now ? now : value;
        }
    }

    public Phone(string model, int price, DateOnly releaseDate)
    {
        Model = model;
        Price = price;
        ReleaseDate = releaseDate;
    }
}