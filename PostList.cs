using Post = (string Name, string Message);

class PostList
{
    List<Post> posts = [];

    public void Add(Post post)
    {
        posts.Add(post);
    }

    public void Write()
    {
        for (int i = 0; i < posts.Count; i++)
        {
            Console.WriteLine($"[{i}] {posts[i].Name} - {posts[i].Message}");
        }
    }
}