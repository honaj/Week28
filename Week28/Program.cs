using System.Drawing;

string[] validProducts = { "CE-400", "XX-480", "LABAN-231", "XY-459" };
List<string> validEntries = new();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Skriv in produkter. Avsluta genom att skriva 'exit'");

//Loop until user types the exit command
while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    var input = Console.ReadLine()?.Trim();
    Console.ForegroundColor = ConsoleColor.Red;

    //Check if input is empty
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Du angav inget produktnamn");
        continue;
    }

    //Break loop on exit command
    if (input.ToLower() == "exit")
        break;

    //Try to split the input in two based on hyphen
    var splitInput = input.Split('-');

    //Check length to filter out inputs with too many or too few hyphens
    if (splitInput.Length != 2)
    {
        Console.WriteLine("Produkten måste anges enligt formatet text-bindestreck-siffra");
        continue;
    }

    //Check if the first part consists only of letters and no spaces
    if (!splitInput.First().All(char.IsLetter) || splitInput[0].Contains(' '))
    {
        Console.WriteLine("Den första delen av namnet måste bestå av bokstäver");
        continue;
    }

    //Check if the number is valid
    if (!int.TryParse(splitInput.Last(), out var productNumber))
    {
        Console.WriteLine("Produkten måste sluta med en siffra");
        continue;
    }

    //Check if number is inside the given range
    if (productNumber < 200 || productNumber > 500)
    {
        Console.WriteLine("Produkten måste sluta med en siffra mellan 200 och 500");
        continue;
    }

    //Finally, check if the input can be found in the array of products
    if (!validProducts.Contains(input, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine("Du angav ett korrekt format, men produkten existerar inte");
        continue;
    }

    Console.ForegroundColor = ConsoleColor.Cyan;

    //If everything checks out, add the input to the list of valid entries
    validEntries.Add(input);
    Console.WriteLine("Produkten hittades och har lagts till");
}

//Quit if no entered products are valid on exit
if (validEntries.Count == 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Du angav inga produkter");
    return;
}

//Print all correctly entered products in alphabetic order
Console.WriteLine("Du angav följande produkter:");

validEntries.Sort();
foreach (var validEntry in validEntries)
{
    Console.WriteLine("* " + validEntry);
}