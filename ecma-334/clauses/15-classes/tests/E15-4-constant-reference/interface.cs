/*
Rules: E15-4-constant-reference
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const IPort Empty = null;
Into: public const IPort Other = null;
*/
using System;
interface IPort { }
class Limits { public const IPort Empty = null; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IPort value = Limits.Empty;
        Check(value == null, "interface-constant-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
