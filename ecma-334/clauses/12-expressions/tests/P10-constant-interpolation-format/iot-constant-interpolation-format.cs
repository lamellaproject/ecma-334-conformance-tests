/*
Rules: P10-constant-interpolation-format
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: $"{Part:x}"
Into: $"{Part}"
*/
class Program
{
    const string Part = "rope";
    const string Value = $"{Part:x}";
    static void Main() { System.Console.WriteLine(Value); }
}
