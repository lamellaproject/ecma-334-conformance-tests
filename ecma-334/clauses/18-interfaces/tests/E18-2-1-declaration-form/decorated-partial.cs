/*
Rules: E18-2-1-declaration-form; E18-2-1-generic-own-parameters
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: : IRead<T> where T : class
Into: where T : class
*/
using System;
class MarkAttribute : Attribute { }
public interface IRead<out T> { T Read(); }
[Mark] public partial interface IText<out T> : IRead<T> where T : class { };
public partial interface IText<out T> where T : class { }
class Text : IText<string> { public string Read() { return "cedar"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IText<string> text = new Text();
        Check(text.Read() == "cedar", "attributed-partial-constructed-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
