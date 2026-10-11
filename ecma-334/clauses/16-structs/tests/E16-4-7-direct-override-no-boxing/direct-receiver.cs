/*
Rules: E16-4-7-direct-override-no-boxing
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
    public override int GetHashCode() { Value ^= 45; return Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(); int result = item.GetHashCode();
        Check(result == 45, "override-result");
        Check(item.Value == 45, "direct-override-updates-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
