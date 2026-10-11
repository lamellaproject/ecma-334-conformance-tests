/*
Rules: E18-2-3-2-output-safe-complement; E18-2-3-2-input-safe-complement
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: interface IReturn<out T>
Into: interface IReturn<in T>
*/
using System;
interface IReturn<out T> { T[] Read(); }
interface IAccept<in T> { void Write(T[] value); }
class Transfer : IReturn<string>, IAccept<string>
{
    public string[] Saved;
    public string[] Read() { return Saved; }
    public void Write(string[] value) { Saved = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Transfer transfer = new Transfer();
        string[] words = new string[] { "pine" };
        ((IAccept<string>)transfer).Write(words);
        IReturn<object> reader = transfer;
        Check(reader.Read() == words, "output-safe-array");
        Check(transfer.Saved == words, "input-safe-array");
        Check((string)reader.Read()[0] == "pine", "safe-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
