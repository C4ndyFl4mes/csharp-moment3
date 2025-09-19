//  Koden är skriven av Isaac Svedin 2025-09-18.

// I börjad hade jag en tuple istället för att ha objekt. Men när jag hade problem med att spara till JSON fil
// bytte jag till objekt. I efterhand var det nog inte det som var felet.
class Post
{
    public required string Name { get; set; }
    public required string Message { get; set; }
}