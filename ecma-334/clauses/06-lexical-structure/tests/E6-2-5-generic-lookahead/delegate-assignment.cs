/*
Rules: E6-2-5-generic-lookahead; E6-2-5-generic-punctuation; E6-2-5-generic-selected-parse
Authority: ECMA-334 7th ed 6.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read<int>
Into: Read
*/
using System;
delegate int Getter();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T>() { return 24; }
    static void Main()
    {
        Getter get = Read<int>;
        Check(get() == 24, "semicolon-retains-type-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
