using System;
using System.Runtime.CompilerServices;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        if (!_isHidden)
        {
            _isHidden = true;
        }
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        StringBuilder hidden = new StringBuilder();

        foreach (char c in _text)
        {
            if (char.IsLetter(c))
            {
                hidden.Append('_');
            }
            else
            {
                hidden.Append(c);
            }
        }
        return hidden.ToString();
    }
}