/*
Rules: E15-3-9-3-nonnested-public
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Token
Into: internal class Token
*/
using System;
public class Token { public int Read() { return 257; } }
public class Packet : Token { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Packet().Read() == 257, "public-nonnested-type-can-base-public-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
