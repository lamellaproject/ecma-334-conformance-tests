/*
Rules: P09-with-member-assignment
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public readonly int Value = 2;
Into: public int Value = 2;
*/
record Packet { public readonly int Value = 2; }
class Program
{
    static void Main()
    {
        Packet seed = new Packet();
        Packet changed = seed with { Value = 4 };
    }
}
