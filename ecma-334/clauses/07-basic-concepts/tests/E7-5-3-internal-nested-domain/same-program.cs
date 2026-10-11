/*
Rules: E7-5-3-internal-nested-domain; E7-5-2-internal-modifier; E7-5-2-class-member-access-kinds
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal static int Read()
Into: private static int Read()
*/
using System;
public class Envelope { internal static int Read() { return 67; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Envelope.Read() == 67, "internal-member-outside-containing-type-in-same-program");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
