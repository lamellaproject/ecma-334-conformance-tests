/*
Rules: E10-3-2-char; E10-3-2-all-pairs
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: char x='=';
Into: char x=default(char);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        char x='='; Check((sbyte)x==61 && (byte)x==61 && (short)x==61, "E10-3-2-char-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
