/*
Rules: E18-2-1-generic-struct-nesting
Authority: ECMA-334 7th ed 18.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public interface IRead { T Read(); }
Into: public interface IRead { long Read(); }
*/
using System;
struct Shelf<T> { public interface IRead { T Read(); } }
class Reader : Shelf<int>.IRead { public int Read() { return 29; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Shelf<int>.IRead reader = new Reader();
        Check(reader.Read() == 29, "containing-struct-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
