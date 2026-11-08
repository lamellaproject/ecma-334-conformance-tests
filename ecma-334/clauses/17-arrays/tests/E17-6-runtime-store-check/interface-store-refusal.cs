/*
Rules: E17-6-runtime-store-check
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"arguments":["foreign"]}
Mutate: object[] alias = entries;
Into: object[] alias = new object[] { entries[0] };
*/
using System;
interface IReading { int Read(); }
class Reading : IReading { public int Read() { return 29; } }
class Other { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Attempt(object[] alias, object incoming, IReading[] entries, IReading kept)
    {
        bool refused = false;
        try { alias[0] = incoming; }
        catch (ArrayTypeMismatchException) { refused = true; }
        catch (Exception) { }
        Check(refused, "interface-array-refuses-nonimplementer");
        Check(alias[0] == (object)kept, "failed-store-retains-element");
        Check(entries[0].Read() == 29, "retained-interface-value");
    }
    static void Main(string[] arguments)
    {
        IReading[] entries = new IReading[1];
        IReading kept = new Reading();
        entries[0] = kept;
        object[] alias = entries;
        object incoming = arguments.Length == 1 ? (object)new Other() : new Reading();
        Attempt(alias, incoming, entries, kept);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
