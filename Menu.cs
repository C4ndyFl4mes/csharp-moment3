//  Koden är skriven av Isaac Svedin 2025-09-18.

class Menu
{
    public int Focused = -1; // Anger vilket menyalternativ som är i fokus.
    public int Selected = -1; // Anger vilket menyalternativ som har valts.
    // En array av menyalternativ.
    private string[] _Items =
    [
        "1. Skriv i gästboken",
        "2. Ta bort inlägg",
        "X. Avsluta"
    ];

    // Skriver ut menyn.
    public void Write()
    {
        Console.WriteLine("Meny");
        Console.WriteLine(new string('-', 20));
        for (int i = 0; i < _Items.Length; i++)
        {
            if (Focused == -1)
            {
                Console.WriteLine($"{_Items[i]}");
            }
            else if (Focused == i)
            {
                if (Focused == Selected)
                {
                    Console.WriteLine($">> {_Items[i]} <<");
                    Selected = -1;
                }
                else
                {
                    Console.WriteLine($"{_Items[i]} <-- Enter för att välja!");
                }
            }
            else
            {
                Console.WriteLine($"{_Items[i]}");
            }
            Console.WriteLine(new string('-', 20));
        }
    }

    // Tar emot tangentknappar. Först sker ett fokus första gången PressKey() kallas, nästa gång den kallas kan enter klickas eller ett annat menyalternativ väljas.
    public ConsoleKey PressKey()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        Console.Clear();
        ConsoleKey keyPressed = keyInfo.Key;
        if (keyInfo.KeyChar == '1')
        {
            Focused = 0;
        }
        else if (keyInfo.KeyChar == '2')
        {
            Focused = 1;
        }
        else if (keyInfo.KeyChar == 'x')
        {
            Focused = -1;
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            if (Focused == -1)
            {
                Console.WriteLine("Kan inte välja när det inte finns något alternativ valt!"); // Ett felmeddelande.
            }
            else
            {
                Selected = Focused; // Anger att nu är ett menyalternativ valt.
            }
        }
        else
        {
            Console.WriteLine($"Knapp {keyInfo.Key} har ingen funktion!"); // Ett felmeddelande.
        }

        return keyPressed;
    }

}