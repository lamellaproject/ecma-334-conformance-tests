/*
Rules: P10-constant-interpolation-nonconstant
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: $"{Part}"
Into: $"{nameof(Part)}"
*/
class Program
{
    static string Part = "rope";
    const string Value = $"{Part}";
    static void Main() { System.Console.WriteLine(Value); }
}
