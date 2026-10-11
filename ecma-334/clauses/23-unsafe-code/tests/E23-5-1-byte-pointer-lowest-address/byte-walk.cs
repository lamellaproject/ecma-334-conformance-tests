/*
Rules: E23-5-1-byte-pointer-lowest-address; E23-5-1-byte-pointer-successive-addresses
Authority: ECMA-334 7th ed 23.5.1
Version: 7.3
Expected: run
Stdout: OK 9
Mutate: byte* first = (byte*)&value;
Into: byte* first = (byte*)&other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        long value = 0, other = 0;
        byte* first = (byte*)&value;
        Check((void*)first == (void*)&value, "lowest-byte-address");
        for (int i = 0; i < sizeof(long); i++) first[i] = (byte)(i + 1);
        byte* current = first;
        for (int i = 0; i < sizeof(long); i++)
        {
            Check(*current == i + 1, "successive-byte");
            current++;
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
