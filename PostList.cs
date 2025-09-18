//  Koden är skriven av Isaac Svedin 2025-09-18.

using Post = (string Name, string Message); // Ett alias för tuple Post.

class PostList
{
    private List<Post> _Posts = []; // Poster.

    // Lägger till en post. Det sker ingen kontroll över unikhet.
    public void Add(Post post)
    {
        _Posts.Add(post);
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
    }

    // Skriver ut gästboken och dess poster.
    public void Write()
    {
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
}