public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(string title, string date, string weatherStatement)
        : base(title, date)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weatherStatement}";
    }
}
