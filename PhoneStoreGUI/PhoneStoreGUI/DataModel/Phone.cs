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
            if (value > now)
            {
                _releaseDate = now;
            }
            else
            {
                _releaseDate = value;
            }
        }
    }

    public Phone(string model, int price, DateTimeOffset releaseDate)
    {
        Model = model;
        Price = price;
        ReleaseDate = DateOnly.FromDateTime(releaseDate.DateTime);
    }
}