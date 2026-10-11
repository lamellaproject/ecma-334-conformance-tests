/*
Rules: E10-3-2-unchecked-integral; E10-3-2-truncate
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked((byte)input)
Into: (byte)0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int input = 511;
        byte result = unchecked((byte)input);
        Check(result == 255, "truncate-byte/low-bits");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
