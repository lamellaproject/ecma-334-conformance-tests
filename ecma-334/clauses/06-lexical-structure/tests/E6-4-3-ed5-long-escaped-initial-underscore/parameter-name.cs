/*
Rules: E6-4-3-ed5-long-escaped-initial-underscore
Authority: ECMA-334 5th ed 7.4.3
Version: 5
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E6-4-3-ed5-long-escaped-initial-underscore/parameter-name.cs.part
Mutate: int \U0000005Ftag
Into: int tag
*/
// ECMA-334 5th ed 7.4.3, p. 20 (PDF p. 42), and 7.4.2, p. 19 (PDF p. 41).
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int \U0000005Ftag) { return _tag; }
    static void Main()
    {
        Check(Read(73) == 73, "long-escaped-initial-underscore/parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
