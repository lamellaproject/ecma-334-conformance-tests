/*
Rules: E23-6-7-plus-pointer-long-operator; E23-6-7-plus-pointer-long-address
Authority: ECMA-334 7th ed 23.6.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* result = offset + pointer;
Into: int* result = pointer - offset;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int* storage = stackalloc int[5];
        storage[1] = 19; storage[2] = 29; storage[3] = 37;
        int* pointer = storage + 2;
        long offset = 1;
        int* result = offset + pointer;
        Check((byte*)result - (byte*)pointer == sizeof(int), "typed-offset-address-scale");
        Check(*result == 37, "typed-offset-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
