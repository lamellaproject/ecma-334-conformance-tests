/*
Rules: P09-with-record-receiver
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: class Packet
Into: record Packet
*/
class Packet { public int Value { get; set; } }
class Program
{
    static void Main()
    {
        Packet seed = new Packet();
        Packet changed = seed with { Value = 4 };
    }
}
