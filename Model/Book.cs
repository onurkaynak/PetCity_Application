public class Book
{
    public string? ISBN { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Language { get; set; }
    public int Pages { get; set; }

    public int PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    public virtual Publisher? Publisher { get; set; }

}