public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string date, string speaker, int capacity)
        : base(title, date)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}
