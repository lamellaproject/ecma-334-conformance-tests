/*
Rules: E12-8-3-regular-format-context; E12-8-3-regular-end-context
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: $"{(choose ? "a" : "b")}"
Into: $"{choose ? "a" : "b"}"
*/
using System;
class Cell { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool choose = true;
        string[] values = new string[] { "a", "b" };
        string parentheses = $"{(choose ? "a" : "b")}";
        string square = $"{values[choose ? 0 : 1]}";
        string braces = $"{new Cell { Value = 3 }.Value}";
        Check(parentheses == "a", "parenthesized-colon-is-not-format-start");
        Check(square == "a", "square-bracket-colon-is-not-format-start");
        Check(braces == "3", "nested-brace-is-not-interpolation-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
