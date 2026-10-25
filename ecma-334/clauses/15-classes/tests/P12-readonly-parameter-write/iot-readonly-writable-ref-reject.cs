/*
Rules: P12-readonly-parameter-write
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Set(ref value);
Into: Set(ref scratch);
Csc: CS8329
*/
class Test
{
    static void Set(ref int value) { value = 19; }
    static void Write(ref readonly int value)
    {
        int scratch = 0;
        Set(ref value);
        System.Console.WriteLine(scratch);
    }
    static void Main() { int cell = 11; Write(in cell); }
}
