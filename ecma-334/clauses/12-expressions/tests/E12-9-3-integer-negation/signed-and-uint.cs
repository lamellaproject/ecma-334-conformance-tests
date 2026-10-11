/*
Rules: E12-9-3-integer-negation; E12-9-3-integer-predefined; E12-9-3-uint-conversion; E12-9-3-uint-result; E12-9-1-form-minus
Authority: ECMA-334 7th ed 12.9.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: -i
Into: +i
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(long x) { return 1; }
    static int Kind(int x) { return 2; }
    static void Main()
    {
        int i = 7; long l = 9000000000L; uint u = 4000000000U;
        Check(-i == -7, "int"); Check(-l == -9000000000L, "long");
        var result = -u;
        Check(result == -4000000000L, "uint-converted-before-negation"); Check(Kind(result) == 1, "uint-result-long");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
