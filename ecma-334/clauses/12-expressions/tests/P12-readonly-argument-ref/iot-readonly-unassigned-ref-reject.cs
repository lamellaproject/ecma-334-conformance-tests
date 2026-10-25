/*
Rules: P12-readonly-argument-ref; E12-6-2-3-input-reference-assigned
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: int value;
Into: int value = 11;
Csc: CS0165
*/
class Test
{
    static void Read(ref readonly int input) { System.Console.WriteLine(input); }
    static void Main() { int value; Read(ref value); }
}
