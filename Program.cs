namespace moment3;

/*
    Koden är skriven av Isaac Svedin 2025-09-18.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        bool isRunning = true; // Programmet är på.
        Menu menu = new(); // Initierar Menyn.
        PostList postList = new();

        do
        {
            menu.Write(); // Skriver ut / uppdaterar Menyn.
            postList.Write(); // Skriver ut alla poster.
            Console.WriteLine("Välj ett menyalternativ!"); // Ett förtydligande meddelande om vad som försegår.
            ConsoleKey keyPressed = menu.PressKey();

            // När x trycks ned när användaren befinner sig i att välja alternativ stängs applikationen.
            // Båda menu.Selected kan endast nås efter att ett menyalternativ har fokus. 
            if (keyPressed == ConsoleKey.X)
            {
                isRunning = false;
            }
            else if (menu.Selected == 0) //Tangent '1' efter fokus och enter.
            {
                menu.Write(); // Skriver ut / uppdaterar Menyn.
                postList.Write(); // Skriver ut alla poster.
                Console.WriteLine("Skriv ditt namn och ett meddelande!"); // Ett förtydligande meddelande om vad som försegår.

                string? nameInput;
                string? messageInput;

                // De är do-while-looparna ser till att ett namn och ett meddelande anges.
                do
                {
                    Console.Write("Namn: ");
                    nameInput = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nameInput));

                do
                {
                    Console.Write("Meddelande: ");
                    messageInput = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(messageInput));

                postList.Add(new Post { Name = nameInput.Trim(), Message = messageInput.Trim() }); // Lägger till en post.
            }
            else if (menu.Selected == 1) // Tangent '2' efter fokus och enter.
            {
                menu.Write(); // Skriver ut / uppdaterar Menyn.
                postList.Write(); // Skriver ut alla poster.
                Console.WriteLine("Radera ett inlägg!"); // Ett förtydligande meddelande om vad som försegår.

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int index))
                {
                    postList.Remove(index);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Det måste vara en siffra!"); // Ett felmeddelande.
                }
            }
            // Har ingen slutande else eftersom den hanteras av PressKey() metoden i Menu.cs. Ett felmeddelande om att alla knappar förutom 1, 2, x och enter har ingen funktion.

        } while (isRunning);
    }
}
