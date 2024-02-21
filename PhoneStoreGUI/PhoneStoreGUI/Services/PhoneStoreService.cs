using System;
using System.Collections.Generic;
using System.IO;
using PhoneStoreGUI.DataModel;

namespace PhoneStoreGUI.Services;

public class PhoneStoreService
{
    public IEnumerable<Phone> GetItems()
    {
        return LoadItems();
    }
    private static IEnumerable<Phone> LoadItems()
    {
        try
        {
            var baseDir = AppContext.BaseDirectory;
            var jsonPath = baseDir + "/.data.json";
            if (File.Exists(jsonPath))
            {
                var text = File.ReadAllText(jsonPath);
                var json = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Phone>>(text);
                return json ?? [];
            }
            return [];
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the list: " + ex.Message);
            return [];
        }
    }

    public static void UpdateItems(IEnumerable<Phone> items)
    {
        try
        {
            var baseDir = AppContext.BaseDirectory;
            var jsonPath = baseDir + "/.data.json";

            var json = System.Text.Json.JsonSerializer.Serialize(items);

            File.WriteAllText(jsonPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the list: " + ex.Message);
        }
    }
}