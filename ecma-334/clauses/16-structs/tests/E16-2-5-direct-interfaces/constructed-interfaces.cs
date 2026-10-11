/*
Rules: E16-2-5-direct-interfaces; E16-2-5-constructed-interfaces; E16-2-5-interface-list-form; E16-4-3-interfaces
Authority: ECMA-334 7th ed 16.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: : IItem<T>, IMarker
Into: : IMarker
*/
using System;
interface IItem<T> { T Read(); }
interface IMarker { }
class Box<T>
{
    public struct Entry : IItem<T>, IMarker
    {
        public T Value;
        public T Read() { return Value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box<string>.Entry value = new Box<string>.Entry(); value.Value = "entry";
        IItem<string> item = value; IMarker marker = value;
        Check(item.Read() == "entry", "substituted-interface");
        Check(marker != null, "second-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
