/*
Rules: E23-3-pointer-as-type; E23-3-form-value-pointer; E23-3-referent-type; E23-3-pointer-unmanaged; E23-3-pointer-referent-pointer; E23-3-indirection-access; E23-3-operator-indirection; E23-3-operator-address
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int* p = &value;
Into: int* p = &other;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 43, other = 47;
            int* p = &value;
            int** pp = &p;
            Check(*p == 43, "typed-pointer-referent");
            Check(**pp == 43, "pointer-referent-pointer");
            *p = 53;
            Check(value == 53, "indirection-variable-write");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
