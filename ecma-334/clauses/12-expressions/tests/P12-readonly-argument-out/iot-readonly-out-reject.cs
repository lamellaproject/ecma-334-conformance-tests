/*
Rules: P12-readonly-argument-out
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Read(out value);
Into: Read(in value);
Csc: CS1615
*/
class Test
{
    static void Read(ref readonly int value) { System.Console.WriteLine(value); }
    static void Main() { int value = 11; Read(out value); }
}
