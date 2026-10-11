/*
Rules: E18-2-1-generic-class-nesting
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public interface IRead { T Read(); }
Into: public interface IRead { long Read(); }
*/
using System;
class Shelf<T> { public interface IRead { T Read(); } }
class Reader : Shelf<int>.IRead { public int Read() { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shelf<int>.IRead reader = new Reader();
        Check(reader.Read() == 23, "containing-class-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
