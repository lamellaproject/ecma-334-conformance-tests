/*
Rules: E15-5-1-grammar-field-modifier-form-9
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe int* Address;
Into: public int* Address;
*/
using System;
class Holder { public unsafe int* Address; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    unsafe static void Main()
    {
        int local = 953;
        Holder value = new Holder();
        value.Address = &local;
        Check(*value.Address == 953, "unsafe-field-modifier-pointer-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
