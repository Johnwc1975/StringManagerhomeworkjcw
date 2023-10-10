
using System;

using System.Collections.Generic;

 

public class StringManager

{

    private string inputString;



    public StringManager(string input)

    {

        inputString = input;

    }



    public string Reverse(string s)

    {

        // Use a stack to reverse the string

        Stack<char> stack = new Stack<char>();

        foreach (char c in s)

        {

            stack.Push(c);

        }



        // Build the reversed string

        char[] reversed = new char[s.Length];

        for (int i = 0; i < s.Length; i++)

        {

            reversed[i] = stack.Pop();

        }



        return new string(reversed);

    }



    public string Reverse(string s, bool preserveCaseLocation)

    {

        // Use a stack to reverse the string while preserving casing location

        Stack<char> stack = new Stack<char>();

        char[] original = s.ToCharArray();

        char[] reversed = new char[s.Length];



        for (int i = 0; i < s.Length; i++)

        {

            if (char.IsLetter(s[i]) && char.IsUpper(s[i]))

            {

                stack.Push(char.ToUpper(original[i]));

            }

            else

            {

                stack.Push(char.ToLower(original[i]));

            }

        }



        for (int i = 0; i < s.Length; i++)

        {

            if (!char.IsLetter(original[i]))

            {

                reversed[i] = original[i];

            }

            else if (char.IsUpper(original[i]))

            {

                reversed[i] = stack.Pop();

            }

            else

            {

                reversed[i] = char.ToLower(stack.Pop());

            }

        }



        return new string(reversed);

    }



    public bool Symmetric(string s)

    {

        // Check if the string is symmetric (case-sensitive)

        string reversed = Reverse(s);

        return s.Equals(reversed);

    }



    public override string ToString()

    {

        if (string.IsNullOrEmpty(inputString))

        {

            return "Negative One";

        }



        int sum = 0;

        foreach (char c in inputString)

        {

            sum += (int)c;

        }



        return ConvertToWords(sum);

    }



    public override bool Equals(object obj)

    {

        if (obj is string)

        {

            return inputString.Equals(obj);

        }

        return false;

    }



    private string ConvertToWords(int num)

    {

        string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        string result = "";

        while (num > 0)

        {

            int digit = num % 10;

            result = units[digit] + " " + result;

            num /= 10;

        }

        return result.Trim();

    }

}



public class Program

{

    public static void Main(string[] args)

    {

        // Test cases

        StringManager stringManager = new StringManager("Sunbeam Tiger");



        Console.WriteLine("1. Reverse a string: " + stringManager.Reverse("Sunbeam Tiger"));

        Console.WriteLine("2. ToString: " + stringManager.ToString());

        Console.WriteLine("3. Reverse a string with preserved casing: " + stringManager.Reverse("Sunbeam Tiger", true));

        Console.WriteLine("4. Equality Check: " + stringManager.Equals("Sunbeam Tiger"));

        Console.WriteLine("5. Symmetric check for 'ABBA': " + stringManager.Symmetric("ABBA"));

        Console.WriteLine("6. Symmetric check for 'ABA': " + stringManager.Symmetric("ABA"));

        Console.WriteLine("7. Symmetric check for 'ABba': " + stringManager.Symmetric("ABba"));

    }

}
