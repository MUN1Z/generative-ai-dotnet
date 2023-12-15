namespace GoogleGenerativeAI;

public record struct Part(string Text);

public record struct Content(IList<Part> Parts)
{
    public Content() : this(new List<Part>()) { }
    public Content(Part part) : this(new List<Part>() { part }) { }
    public Content(string part) : this(new List<Part>() { new Part(part) }) { }
}

public record struct Candidate(Content Content)
{
    public Candidate(Part part) : this(new Content(part)) { }
    public Candidate(string part) : this(new Content(part)) { }
}

public class RequestModel
{
    public IList<Content> Contents { get; set; }

    public RequestModel()
        => Contents = new List<Content>();

    public RequestModel(Content content) : this()
        => Contents.Add(content);

    public RequestModel(IList<Content> contents) : this()
        => Contents = contents;

    public RequestModel(Part part) : this()
        => Contents.Add(new Content(part));

    public RequestModel(string message) : this()
        => Contents.Add(new Content(message));

}

public class ResponseModel
{
    public List<Candidate> Candidates { get; set; }

    public ResponseModel()
        => Candidates = new List<Candidate>();
}
