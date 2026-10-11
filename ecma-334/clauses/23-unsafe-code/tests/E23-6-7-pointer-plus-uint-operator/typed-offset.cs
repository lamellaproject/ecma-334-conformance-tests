/*
Rules: E23-6-7-pointer-plus-uint-operator; E23-6-7-pointer-plus-uint-address
Authority: ECMA-334 7th ed 23.6.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* result = pointer + offset;
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
        uint offset = 1;
        int* result = pointer + offset;
        Check((byte*)result - (byte*)pointer == sizeof(int), "typed-offset-address-scale");
        Check(*result == 37, "typed-offset-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
