/*
Rules: E16-2-1-declaration; E16-2-1-form; E16-2-1-name; E16-2-1-generic-parameters; E16-2-2-modifier-public; E16-2-2-modifier-readonly
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class
Into: where T : struct
*/
using System;
class StampAttribute : Attribute { }
interface IItem { }
[Stamp] public readonly struct Named<T> : IItem where T : class
{
    public readonly T Item;
    public Named(T item) { Item = item; }
};
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Named<string> item = new Named<string>("entry");
        Check(item.Item == "entry", "attributed-generic-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
