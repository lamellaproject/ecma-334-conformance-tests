/*
Rules: P09-with-instance-member
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: seed with { Absent = 4 }
Into: seed with { Value = 4 }
*/
record Packet { public int Value { get; init; } }
class Program
{
    static void Main()
    {
        Packet seed = new Packet();
        Packet changed = seed with { Absent = 4 };
    }
}
