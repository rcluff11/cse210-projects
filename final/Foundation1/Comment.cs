public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetDetails()
    {
        return $"  - {_commenterName}: {_text}";
    }
}
