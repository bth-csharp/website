---
title: "Filer med JSOM data"
description: Filer med JSON data
sidebar:
    order: 7
    hidden: true
---

## Skapa ett projekt eller fortsätt på FileApp

Vi fortsätter med [shoppinglistan](./../../kmom03/Kunskap/File.md) som vi gjorde i kmom03. Där hade vi en shoppinglista där varje rad innehöll produkten som skulle handlas och antalet. Shoppinglistan såg ut så här:

```text
Din shoppinglista
kaffe 2
te 1
```

Gör ett projekt i kmom06 som heter "FileApp".

```shell
dotnet new console -n FileApp
```

Fortsätt i **FileApp** som vi skapade i [Filer](./../../kmom03/Kunskap/File.md). Kopiera koden du gjorde där och lägg den under kmom06.

## Läs och skriv JSON data - kodexempel med StreamReader och StreamWriter

När det inte räcker att spara ner strängar i filer är det vanligt att spara ner datan i JSON objekt. Vi skapar en klass **SimpleJson** som gör det. För att göra JSON omvandlingen enklare, så skapar vi en privat klass för ändamålet och kallar den **ProductData**. JSON (JavaScript Object Notation) är ett format som kodar objekt till en sträng. Serialisering innebär att konvertera ett objekt till den strängen, medan deserialisering är den omvända operationen (konvertera sträng till objekt).


### Klassen ProductData

Vi skapar klassen **ProductData** som har två attribut `Produkt` som är namnet på produkten och `Quantity` som är antalet produkter. **ProductData** används för att spara data på fil i json-format.

<details>
<summary>Koden till ProductData</summary>

```csharp
// kmom06/FileApp/src/ProductData.cs
namespace FileApp.src;

public class ProductData
{
    public string? Product { get; set; }
    public string? Quantity { get; set; }
}
```

</details>

### JSON-filen

<details>
<summary>Så här kan innehållet i filen se ut:</summary>
Så här kan innehållet i filen se ut:

```csharp
// kmom06/FileApp/simpleList.json
[
  {
    "Product": "te",
    "Quantity": "1"
  },
  {
    "Product": "kaffe",
    "Quantity": "2"
  }
]
```

</details>

### Klassen SimpleJson

I det här exemplet använder vi klassen **StreamReader** som används för att läsa text från en fil. Den har metoderna `Read` som läser ett tecken, `ReadLine` som läser en rad av text, och `ReadToEnd` läser all text från strömmen till slutet. Det är viktigt att komma ihåg att stänga ner **StreamReader** med metoden `close` när vi använt den. Om vi som här i exemplet använder "using", så stängs filen automatiskt.

<details>
<summary>Koden till SimpleJson</summary>

```csharp
// kmom06/FileApp/src/SimpleJson.cs
namespace FileApp.src;

using System;
using System.IO;
using System.Text.Json;

public class SimpleJson
{
    private string _filename;

    public SimpleJson(string filename)
    {
        this._filename = @filename;
    }

    public void Save(string line)
    {
        try
        {
            string[] lineSplit = line.Split(' ');
            var dataToSave = new ProductData();
            List<ProductData> dataList = Read();

            dataToSave.Product = lineSplit[0];
            dataToSave.Quantity = lineSplit[1];
            dataList.Add(dataToSave);

            // Konvertera data till JSON-sträng
            string jsonString = JsonSerializer.Serialize(dataList, new JsonSerializerOptions() { WriteIndented = true });

            // Skapa en StreamWriter för att skriva JSON till filen
            using (StreamWriter writer = new StreamWriter(this._filename))
            {
                writer.WriteLine(jsonString);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett fel inträffade vid skrivning filen: {ex.Message}");
        }
    }

    private List<ProductData> Read()
    {
        string? jsonData;
        List<ProductData> dataList = new List<ProductData>();

        if (File.Exists(this._filename))
        {
            // Läs JSON från filen
            using (StreamReader reader = new StreamReader(this._filename))
            {
                jsonData = reader.ReadToEnd();
            }

            // Konvertera JSON till objekt
            dataList = JsonSerializer.Deserialize<List<ProductData>>(jsonData) ?? new List<ProductData>();
        }

        return dataList;
    }

    public void Present()
    {
        Console.WriteLine("\nDin shoppinglista");
        try
        {
            List<ProductData> dataList = Read();

            if (dataList.Count == 0)
            {
                Console.WriteLine("Listan är tom");
                return;
            }
            foreach (ProductData row in dataList)
            {
                Console.WriteLine(row.Product + " " + row.Quantity);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett fel inträffade vid läsning av filen: {ex.Message}");
        }
    }

    public void CheckQuantity(string quantity)
    {
        int checkedQuantity;
        
        if (string.IsNullOrWhiteSpace(quantity) || quantity.Length == 0)
        {
            throw new QuantityException("Antalet får inte vara tomt!");
        }
        if (!int.TryParse(quantity, out checkedQuantity))
        {
            throw new QuantityException("Du matade inte in ett tal! Talet ska vara 1 <= tal <= 20!");
        }
        if (checkedQuantity > 20)
        {
            throw new QuantityException("Du matade in ett för stort tal, 1 <= tal <= 20!");
        }
        if (checkedQuantity < 1)
        {
            throw new QuantityException("Du matade in ett för litet tal, 1 <= tal <= 20!");
        }
    }
}
```

</details>

Dessutom så läser vi upp all JSON data och lägger till vår nya data innan vi sparar ner på fil med klassen **StreamWriter**. **StreamWriter** har bland annat metoderna `Write` som skriver en serie tecken och `WriteLine` som lägger till en radbrytning efter att ha skrivit till filen. **StreamReader** och **StreamWriter** måste stängas och det gör vi automatiskt genom att använda konstruktionen med "using".

### Huvudprogrammet

Vi uppdatera vårt program för att kunna köra med klassen **SimpleJson** istället.

<details>
<summary>Koden till huvudprogrammet</summary>

```csharp
// kmom06/FileApp/Program.cs
using FileApp.src;

SimpleJson shoppingList = new SimpleJson("simpleList.json");

shoppingList.Present();
bool enterProduct = true;
bool checkQuantity = true;

while (enterProduct)
{
    string? product;
    string quantity = string.Empty;

    Console.Write("\nAnge produktnamn (eller ENTER för att sluta): ");
    product = Console.ReadLine() ?? "";
    if (product == "") 
    { 
        enterProduct = false; // För att avsluta yttre loopen
    }
    else
    {
        while (checkQuantity)
        {
            Console.Write("\nAnge antal: ");
            try
            {
                quantity = Console.ReadLine() ?? "";
                shoppingList.CheckQuantity(quantity);
                checkQuantity = false; // Allt är ok, inga fler kontroller behövs
            }
            catch (QuantityException exQ)
            {
                Console.WriteLine(exQ.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        string saveInput = $"{product} {quantity}";
        shoppingList.Save(saveInput);
        // Återställ för ny kontroll av antalet
        checkQuantity = true;
    }
}

shoppingList.Present();
```

</details>

Då testkör vi programmet. Kolla att shoppinglistan är tom första gången du startar programmet. Lägg till en produkt och avsluta programmet. Starta programmet igen och se att shoppinglistan ser ut som innan.

### **ProductData** som intern klass istället

Eftersom det bara är klassen **SimpleJson** som använder klassen **ProductData** så skulle **ProductData** kunna varit en "intern klass" till **SimpleJson**. I så fall så deklarerar vi den som en intern klass med nyckelordet `internal` sist i filen `SimpleJson.cs`. Då är det bara klassen **SimpleJson** som finns i samma fil som kommer åt den. Det är bra då vi vill begränsa användningen av klassen **ProductData** och gömma den för andra klasser genom att kapsla in den. Vi tar då bort filen `ProductData.cs` som innehåller klassen **ProductData** och gör det till en intern klass.

<details>
<summary>Koden till SimpleJson med intern klass</summary>

```csharp
namespace FileApp.src;

using System;
using System.IO;
using System.Text.Json;

public class SimpleJson
{
    private string _filename;

    public SimpleJson(string filename) ...

    public void Save(string line) ...

    private List<ProductData> Read() ...

    public void Present() ...

    public void CheckQuantity(string quantity) ...
}

internal class ProductData
{
    public string? Product { get; set; }
    public string? Quantity { get; set; }
}
```

</details>

### Json2CSharp

Du kan använda [Json2CSharp](https://json2csharp.com/) för att generera C#-klasser från din JSON-data om du behöver hjälp med det.

### Sammanfattning

Då har vi tittat på hur vi kan skriva till filer på olika sätt, både vanliga strängar och JSON data. Vi har använt oss av "File", "StreamReader" och "StreamWriter". För att vi inte ska glömma att stänga filer vi öppnar med "StreamReader" och "StreamWriter" så använder vi oss av konstruktionen "using". Klassen "File" stänger filerna automatiskt.

Detta är två exempel på hur vi kan läsa och skriva till fil. Det finns mer exempel här i referensmanualen [File Class](https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-9.0). Här kan du läsa mer om [StreamWriter](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-9.0) och [StreamReader](https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-9.0).

Se kodexemplet [FileApp](./../../../CodeExamples/kmom06/FileApp).
