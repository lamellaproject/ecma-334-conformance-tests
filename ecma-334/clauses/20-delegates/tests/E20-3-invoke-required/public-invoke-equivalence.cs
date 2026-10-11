/*
Rules: E20-3-invoke-required; E20-3-invoke-parameters; E20-3-invoke-return-type; E20-3-invoke-accessibility; E20-3-invoke-equivalence
Authority: ECMA-334 7th ed 20.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: delegate int Read(int first, int second = 3);
Into: delegate int Read(int first);
*/
using System;
namespace Contract { public delegate int Read(int first, int second = 3); }
class Program
{
    static int checks, failures;
    static int calls, savedFirst, savedSecond;
    static int ReadValue(int first, int second)
    {
        calls++; savedFirst = first; savedSecond = second; return first * 10 + second;
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Contract.Read read = ReadValue;
        Check(read(10) == 103, "delegate-syntax-default-argument");
        Check(calls == 1 && savedFirst == 10 && savedSecond == 3, "delegate-syntax-parameters");
        Check(read.Invoke(10) == 103, "public-invoke-return-and-default");
        Check(calls == 2 && savedFirst == 10 && savedSecond == 3, "invoke-equivalent-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
