/*
Rules: E18-6-1-class-implementation; E18-6-1-base-list-direct-implementation; E18-6-1-derived-implementation; E18-6-1-constructed-interfaces; E18-6-5-constructed-member-substitution
Authority: ECMA-334 7th ed 18.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Reader<T> : IRead<T>
Into: class Reader<T>
*/
using System;
interface IRead<T> { T Read(); }
class Reader<T> : IRead<T>
{
    T value;
    public Reader(T value) { this.value = value; }
    public T Read() { return value; }
}
class TextReader : Reader<string> { public TextReader() : base("willow") { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead<int> direct = new Reader<int>(149);
        IRead<string> inherited = new TextReader();
        Check(direct.Read() == 149, "direct-constructed-interface");
        Check(inherited.Read() == "willow", "derived-class-implicit-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
