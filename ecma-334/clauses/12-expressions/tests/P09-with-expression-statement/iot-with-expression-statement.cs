/*
Rules: P09-with-expression-statement
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: seed with { Value = 4 };
Into: Packet changed = seed with { Value = 4 };
*/
record Packet { public int Value { get; init; } }
class Program
{
    static void Main()
    {
        Packet seed = new Packet();
        seed with { Value = 4 };
    }
}
