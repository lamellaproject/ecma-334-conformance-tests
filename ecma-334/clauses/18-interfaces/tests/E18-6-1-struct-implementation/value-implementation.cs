/*
Rules: E18-6-1-struct-implementation
Authority: ECMA-334 7th ed 18.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Reader : IRead
Into: struct Reader
*/
using System;
interface IRead { int Read(); }
struct Reader : IRead { public int Read() { return 151; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead view = new Reader();
        Check(view.Read() == 151, "struct-interface-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
