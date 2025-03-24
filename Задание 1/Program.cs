using System;

public delegate string TextProcessor(string input);

class UpperCaseConverter
{
    public string ConvertToUpper(string input)
    {
        return input.ToUpper();
    }
}

class LowerCaseConverter
{
    public string ConvertToLower(string input)
    {
        return input.ToLower();
    }
}

class Program
{
    static void Main()
    {
        UpperCaseConverter upperCaseConverter = new UpperCaseConverter();
        LowerCaseConverter lowerCaseConverter = new LowerCaseConverter();

        TextProcessor upperProcessor = new TextProcessor(upperCaseConverter.ConvertToUpper);
        TextProcessor lowerProcessor = new TextProcessor(lowerCaseConverter.ConvertToLower);

        string inputText = "Hello, World!";

        string upperResult = upperProcessor(inputText);
        string lowerResult = lowerProcessor(inputText);

        Console.WriteLine($"Исходный текст: {inputText}");
        Console.WriteLine($"В верхнем регистре: {upperResult}");
        Console.WriteLine($"В нижнем регистре: {lowerResult}");
    }
}