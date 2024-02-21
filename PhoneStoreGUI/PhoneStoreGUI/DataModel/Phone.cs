using System;

namespace PhoneStoreGUI.DataModel;

public class Phone
{
    private DateTimeOffset _releaseDate;

    public string Model { get; init; }
    public int Price { get; init; }
    public DateTimeOffset ReleaseDate
    {
        get => _releaseDate;
        init
        {
            //var now = DateOnly.FromDateTime(DateTime.Now);
            var now = DateTime.Now;
            _releaseDate = value > now ? now : value;
        }
    }

    public Phone(string model, int price, DateTimeOffset releaseDate)
    {
        Model = model;
        Price = price;
        ReleaseDate = releaseDate;
    }

    public DateOnly GetReleaseDate
    {
        get => DateOnly.FromDateTime(ReleaseDate.DateTime);
    }
}