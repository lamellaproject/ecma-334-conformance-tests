/*
Rules: E18-2-3-3-contravariance; E18-2-3-1-annotation-in; E18-2-3-1-contravariant
Authority: ECMA-334 7th ed 18.2.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: interface IWrite<in T>
Into: interface IWrite<T>
*/
using System;
interface IWrite<in T> { void Write(T value); }
class Writer : IWrite<object>
{
    public object Saved;
    public void Write(object value) { Saved = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Writer writer = new Writer();
        IWrite<object> source = writer;
        IWrite<string> destination = source;
        IWrite<object> identity = source;
        destination.Write("ash");
        Check((string)writer.Saved == "ash", "reverse-reference-argument-conversion");
        Check((object)source == (object)destination, "contravariant-instance");
        Check(identity == source, "identity-argument-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
