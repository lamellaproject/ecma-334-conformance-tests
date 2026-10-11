/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Mark Value;
Into: public Mark Value = Mark.Ready;
*/
using System;
enum Mark { Empty = -1, Ready = 5 }
class Holder { public Mark Value; public static Mark Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((int)new Holder().Value == 0, "instance-enum-default-unnamed-zero");
        Check((int)Holder.Global == 0, "static-enum-default-unnamed-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
