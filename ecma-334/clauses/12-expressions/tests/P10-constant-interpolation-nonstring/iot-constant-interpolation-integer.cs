/*
Rules: P10-constant-interpolation-nonstring
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: $"{17}"
Into: $"{"17"}"
*/
class Program
{
    const string Value = $"{17}";
    static void Main() { System.Console.WriteLine(Value); }
}
