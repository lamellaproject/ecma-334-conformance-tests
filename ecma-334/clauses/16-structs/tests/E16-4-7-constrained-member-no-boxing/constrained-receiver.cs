/*
Rules: E16-4-7-constrained-member-no-boxing; E16-4-7-constrained-variable-receiver
Authority: ECMA-334 7th ed 16.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: item.Store(157);
Into: ((IStore)item).Store(157);
*/
using System;
interface IStore { void Store(int value); }
struct Entry : IStore
{
    public int Value;
    public void Store(int value) { Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Store<T>(ref T item) where T : struct, IStore { item.Store(157); }
    static void Main()
    {
        Entry item = new Entry(); Store(ref item);
        Check(item.Value == 157, "constrained-interface-updates-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
