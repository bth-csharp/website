---
title: "C# classlib"
description: Classlib
sidebar:
    order: 8
    hidden: true
---

Tidigare har vi enbart skapat körbara konsolprojekt med `dotnet new console`. Ibland vill vi skapa klassbibliotek som fler projekt kan använda. Då kan vi skapa biblioteksprojekt med `dotnet new classlib`. Biblioteksprojekten är inte körbara utan används i konsolprojekt.

## Skapa ett klassbibliotek

Vi börjar med att skapa en katalog "classlibPractice" i "dbwebb-kurser/csharp/kmom06" och går ner i den.

Det ser ut så här i terminalen. `$HOME` motsvarar katalogen som du skapade "dbwebb-kurser" i.

```bash
pwd
// ger utskriften: $HOME/dbwebb-kurser/csharp/kmom06/classlibPractice
```

Vi skapar ett klassbibliotek med följande kommando:

```bash
dotnet new classlib -n MyLibrary

tree -L 2
// ger utskriften:
// .
// ├── MyLibrary
// │   ├── Class1.cs
// │   ├── MyLibrary.csproj
// │   ├── bin
// │   └── obj
// └── classlibPractice.sln
```

Vi byter namn på klassen och filen (Class1.cs) till `Calculator` och lägger till en metod.

```csharp
// I MyLibrary/Calculator.cs
namespace MyLibrary;

public class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    //public static int Add(int a, int b) => a + b;
}
```

## Skapa konsolprojekt

Nu skapar vi konsolprojektet som ska använda klassbiblioteket `MyLibrary`.

```bash
dotnet new console -n MyApp

tree -L 2
// ger utskriften:
// .
// ├── MyApp
// │   ├── MyApp.csproj
// │   ├── Program.cs
// │   └── obj
// ├── MyLibrary
// │   ├── Calculator.cs
// │   ├── MyLibrary.csproj
// │   ├── bin
// │   └── obj
// └── classlibPractice.sln
```

Vi lägger till en referens till klassbiblioteket `MyLibrary` i konsolprojektet `MyApp` i terminalen.

```bash
cd MyApp
dotnet add reference ../MyLibrary/MyLibrary.csproj
```

Vi kontrollerar att referensen till klassbiblioteket finns i "MyApp/MyApp.csproj".

## Kör konsolprojektet

Vi uppdaterar först konsolprojektet med kod som anropar klassbiblioteket.

```csharp
// I MyApp/MyApp.csproj
using MyLibrary;

var calc = new Calculator();
Console.WriteLine($"2 + 3 = {calc.Add(2, 3)}");
```

Då är det dags att testköra konsolprojektet i terminalen:

```bash
dotnet run
// ger utskriften: 2 + 3 = 5
```

## Skapa ett testprojekt som testar klassbiblioteket

Vi skapar ett testprojekt i katalogen "classlibPractice" med terminalen. Vi lägger också till en referens till klassbiblioteket "MyLibrary".

```bash
dotnet new nunit -n MyLibrary.Tests
dotnet add MyLibrary.Tests/MyLibrary.Tests.csproj reference MyLibrary/MyLibrary.csproj
tree -L 1
// ger utskriften:
// .
// ├── MyApp
// ├── MyLibrary
// ├── MyLibrary.Tests
// └── classlibPractice.sln
```

### Lägg till ett testfall

Vi uppdaterar "MyLibrary.Tests/UnitTest1.cs:

```csharp
using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

public class CalculatorTests
{
    [Test]
    public void Add_ReturnsCorrectSum()
    {
        Assert.That(Calculator.Add(6, 4), Is.EqualTo(10));
    }
}

```

Vi kör testfallet med `dotnet test`.

## Sammanfattning

Då har vi tittat på hur vi kan göra ett klassbibliotek (classlib) som vi kan använda i ett konsolprojekt (console).

Se kodexemplet [classlibPractice](../../../CodeExamples/kmom06/classlibPractice).
