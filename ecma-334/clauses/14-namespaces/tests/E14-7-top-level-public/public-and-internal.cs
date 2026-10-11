/*
Rules: E14-7-top-level-public; E14-7-top-level-internal
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Visible
Into: private class Visible
*/
using System;
namespace Harbor { public class Visible { public const int Code = 29; } internal class Inside { public const int Code = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Harbor.Visible.Code == 29, "public-namespace-type");
        Check(Harbor.Inside.Code == 31, "internal-namespace-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
