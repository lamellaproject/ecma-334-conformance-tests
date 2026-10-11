/*
Rules: E12-8-19-unchecked-constant; E12-8-19-unchecked-truncation
Authority: ECMA-334 7th ed 12.8.19
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: unchecked((byte)515)
Into: checked((byte)515)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const byte residue = unchecked((byte)515);
        const short signed = unchecked((short)65535);
        Check(residue == 3, "constant-low-byte");
        Check(signed == -1, "constant-signed-low-word");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
