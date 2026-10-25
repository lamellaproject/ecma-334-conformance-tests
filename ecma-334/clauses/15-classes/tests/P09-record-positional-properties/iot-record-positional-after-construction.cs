/*
Rules: P09-record-positional-properties
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: item.Depth = 8;
Into: item = new Gauge(4) { Depth = 8 };
Csc: CS8852
*/
record Gauge(int Depth);
class Program
{
    static void Main()
    {
        Gauge item = new Gauge(4);
        item.Depth = 8;
    }
}
