/*
Rules: P12-readonly-parameter-write
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: ref readonly int value
Into: ref int value
Csc: CS8331
*/
class Test
{
    static void Write(ref readonly int value) { value = 19; }
    static void Main() { int cell = 11; Write(ref cell); }
}
