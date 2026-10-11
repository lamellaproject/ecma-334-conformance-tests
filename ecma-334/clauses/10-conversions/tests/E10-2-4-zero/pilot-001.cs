/*
Rules: E10-2-4-zero; E10-2-4-wrap; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Label a=Z;
Into: Label a=(Label)1;
*/
using System;

enum Label : ushort { Mark = 61 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const uint Z = 0; const long L = 0;
        Label a=Z; Label? b=L; Label c=unchecked(91-91);
        Check((ushort)a==0 && b.HasValue && (ushort)b.Value==0 && (ushort)c==0, "E10-2-4-zero-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
