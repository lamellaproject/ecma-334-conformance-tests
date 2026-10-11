/*
Rules: E16-4-12-2-formal-parameter-caller
Authority: ECMA-334 7th ed 16.4.12.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return argument;
Into: return new int[1];
*/
using System;
ref struct Entry
{
    public Span<int> Data;
    public Entry(Span<int> data) { Data = data; }
    public Entry Self() { return this; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Span<int> Read(Span<int> argument) { return argument; }
    static void Main()
    {
        int[] data = new int[1]; data[0] = 181;
        Span<int> result = Read(data);
        Check(result[0] == 181, "formal-parameter-return");
        result[0] = 37;
        Check(data[0] == 37, "formal-parameter-return-retains-storage");
        Entry receiver = new Entry(data); Entry returned = receiver.Self(); returned.Data[0] = 41;
        Check(data[0] == 41, "this-parameter-return-retains-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
