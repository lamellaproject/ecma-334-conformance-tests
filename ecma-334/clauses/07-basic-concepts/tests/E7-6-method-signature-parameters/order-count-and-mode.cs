/*
Rules: E7-6-method-signature-parameters
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: Read(string first, int second)
Into: Read(int first, string second)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { return 17; }
    static int Read(int value) { return 19; }
    static int Read(ref int value) { return 23; }
    static int Read(int first, string second) { return 29; }
    static int Read(string first, int second) { return 31; }
    static void Main()
    {
        int value = 5;
        Check(Read() == 17, "method-zero-parameters");
        Check(Read(value) == 19, "method-one-value-parameter");
        Check(Read(ref value) == 23, "method-one-ref-parameter");
        Check(Read(1, "ash") == 29, "method-parameter-types-int-string");
        Check(Read("ash", 1) == 31, "method-parameter-types-string-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
