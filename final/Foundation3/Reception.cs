public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string date, string rsvpEmail)
        : base(title, date)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }
}
