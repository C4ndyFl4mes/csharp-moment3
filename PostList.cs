//  Koden är skriven av Isaac Svedin 2025-09-18.

using System.Text.Json;

class PostList
{
    private List<Post> _Posts = []; // Poster.

    // Lägger till en post. Det sker ingen kontroll över unikhet.
    public void Add(Post post)
    {
        _Posts.Add(post);
        SaveToFile(); // Sparar till fil.
    }

    // Raderar en post. Ser till att posten existerar innan radering.
    public void Remove(int index)
    {
        Console.Clear();
        if (_Posts.Count - 1 >= index && index >= 0)
        {
            _Posts.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Posten finns inte!"); // Ett felmeddelande.
        }
        SaveToFile(); // Sparar till fil.
    }

    // Skriver ut gästboken och dess poster.
    public void Write()
    {
        LoadFromFile(); // Laddar in filinnehåll.
        int longestPost = 0;
        for (int i = 0; i < _Posts.Count; i++)
        {
            int temp = (_Posts[i].Name + _Posts[i].Message).Length;
            if (longestPost < temp)
            {
                longestPost = temp;
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("Gästboken");
        Console.WriteLine(new string('-', longestPost + 10));
        for (int i = 0; i < _Posts.Count; i++)
        {
            Console.WriteLine($"[{i}] {_Posts[i].Name} - {_Posts[i].Message} \n");
        }
        Console.WriteLine(new string('-', longestPost + 10));
    }

    // Sparar List<Post> _Posts till JSON fil.
    private void SaveToFile()
    {
        string fileName = "Posts.json";
        string jsonString = JsonSerializer.Serialize(_Posts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonString);
    }

    // Laddar från JSON fil och sätter _Posts med den datan ifall det inte är null.
    private void LoadFromFile()
    {
        string jsonFromFile = File.ReadAllText("Posts.json");
        List<Post>? temp = JsonSerializer.Deserialize<List<Post>>(jsonFromFile);
        if (temp == null)
        {
            Console.WriteLine("Det finns inga poster att läsa in!"); // Ett felmeddelande.
        }
        else
        {
            _Posts = temp;
        }
    }
}