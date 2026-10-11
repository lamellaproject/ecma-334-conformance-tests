/*
Rules: E16-4-6-class-upcast-identity; E16-4-6-class-downcast-identity
Authority: ECMA-334 7th ed 16.4.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: object boxed = original;
Into: object boxed = new Entry();
*/
using System;
interface ITag { }
class Entry : ITag { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry original = new Entry(); original.Value = 137;
        object boxed = original; ITag tag = original;
        Entry fromObject = (Entry)boxed; Entry fromInterface = (Entry)tag;
        Check((object)original == boxed, "object-upcast-identity");
        Check(fromObject == original, "object-downcast-identity");
        Check(fromInterface == original && fromInterface.Value == 137, "interface-downcast-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
