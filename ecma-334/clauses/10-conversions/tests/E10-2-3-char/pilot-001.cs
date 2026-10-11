/*
Rules: E10-2-3-char; E10-2-3-exact
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: ushort a=x;
Into: ushort a=default(ushort);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char x = (char)1329;
        ushort a=x; int b=x; uint c=x; long d=x; ulong e=x; float f=x; double g=x; decimal h=x;
        Check(a==1329 && b==1329 && c==1329 && d==1329 && e==1329 && f==1329 && g==1329 && h==1329, "E10-2-3-char-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
