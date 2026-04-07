public abstract class Event
{
    private string _title;
    private string _date;

    public Event(string title, string date)
    {
        _title = title;
        _date = date;
    }

    protected string GetStandardDetails()
    {
        return $"{_title} ({_date})";
    }

    public abstract string GetFullDetails();
}
