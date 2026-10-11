/*
Rules: E23-6-8-less-operator; E23-6-8-less-unsigned-addresses
Authority: ECMA-334 7th ed 23.6.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: bool forward = low < high;
Into: bool forward = low > high;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        byte* storage = stackalloc byte[2];
        byte* low = storage;
        void* high = storage + 1;
        char* same = (char*)storage;
        bool forward = low < high;
        bool backward = high < low;
        bool equalAddress = low < same;
        Check(forward == true, "comparison-forward-addresses");
        Check(backward == false, "comparison-backward-addresses");
        Check(equalAddress == false, "comparison-equal-addresses");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
