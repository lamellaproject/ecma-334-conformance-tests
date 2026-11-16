/*
Rules: P12-readonly-argument-in
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: int value = 11;
Into: long value = 11;
Csc: CS1503
*/
class Test
{
    static void Read(ref readonly long input) { System.Console.WriteLine(input); }
    static void Main() { int value = 11; Read(in value); }
}
