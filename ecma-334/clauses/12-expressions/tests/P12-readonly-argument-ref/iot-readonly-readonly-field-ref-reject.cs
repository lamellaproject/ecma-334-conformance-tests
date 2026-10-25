/*
Rules: P12-readonly-argument-ref; E15-5-3-1-readonly-other-ref
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Read(ref value);
Into: Read(in value);
Csc: CS0199
*/
class Test
{
    static readonly int value = 11;
    static void Read(ref readonly int input) { System.Console.WriteLine(input); }
    static void Main() { Read(ref value); }
}
