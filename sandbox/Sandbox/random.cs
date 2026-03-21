public class PhysicalProduct : Program3
{
    private double _weight;

    public PhysicalProduct(string name, string sku, double weight) : base(name, sku)
    {
        _weight = weight;
    }

    public string GetInfo()
    {
        return $"Physical Item: {_name} ({_sku}) - Weight: {_weight}kg";
    }
}

public class DigitalProduct : Program3
{
    private string _downloadUrl;

    public DigitalProduct(string name, string sku, string downloadUrl) : base(name, sku)
    {
        _name = name;
        _sku = sku;
        _downloadUrl = downloadUrl;
    }

    public string GetInfo()
    {
        return $"Digital Item: {_name} ({_sku}) - Link {_downloadUrl}";
    }
}