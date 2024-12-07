using System;

interface ITextFormatter
{
    string Format(string text);
}

class PlainTextFormatter : ITextFormatter
{
    public string Format(string text) => text;
}

class BoldTextDecorator : ITextFormatter
{
    private readonly ITextFormatter _formatter;

    public BoldTextDecorator(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public string Format(string text) => $"**{_formatter.Format(text)}**";
}

class ItalicTextDecorator : ITextFormatter
{
    private readonly ITextFormatter _formatter;

    public ItalicTextDecorator(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public string Format(string text) => $"*{_formatter.Format(text)}*";
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        ITextFormatter plainText = new PlainTextFormatter();
        ITextFormatter boldText = new BoldTextDecorator(plainText);
        ITextFormatter italicText = new ItalicTextDecorator(boldText);

        string result = italicText.Format("Hello, Markdown!");
        Console.WriteLine(result);
    }
}
