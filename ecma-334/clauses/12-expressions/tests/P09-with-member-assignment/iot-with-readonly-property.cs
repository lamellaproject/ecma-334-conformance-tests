/*
Rules: P09-with-member-assignment
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public int Value { get; }
Into: public int Value { get; init; }
*/
record Packet { public int Value { get; } }
class Program
{
    static void Main()
    {
        Packet seed = new Packet();
        Packet changed = seed with { Value = 4 };
    }
}
