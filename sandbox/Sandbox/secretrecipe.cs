using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class SecretFamilyRecipe
{
    public List<string> _ingredients = new List<string>();
    public List<string> _directions = new List<string>();

    public SecretFamilyRecipe()
    {
        
    }

    public void display()
    {
        foreach (string ingredient in _ingredients)
        {
        Console.WriteLine(ingredient);
        }

        foreach (string directions in _directions)
        {
        Console.WriteLine(directions);
        }
    }
}