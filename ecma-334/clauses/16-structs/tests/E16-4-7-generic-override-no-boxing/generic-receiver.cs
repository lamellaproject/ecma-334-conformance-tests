/*
Rules: E16-4-7-generic-override-no-boxing
Authority: ECMA-334 7th ed 16.4.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: item.GetHashCode()
Into: ((object)item).GetHashCode()
*/
using System;
struct Entry
{
    public int Value;
    public override int GetHashCode() { Value ^= 53; return Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T>(ref T item) where T : struct { return item.GetHashCode(); }
    static void Main()
    {
        Entry item = new Entry(); int result = Read(ref item);
        Check(result == 53, "generic-override-result");
        Check(item.Value == 53, "generic-override-updates-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
