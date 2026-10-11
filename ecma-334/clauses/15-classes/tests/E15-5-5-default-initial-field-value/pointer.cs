/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int* Address;
Into: public int* Address = (int*)1;
*/
using System;
// 23.3 specifies null as the default value for pointer types.
unsafe class Holder { public int* Address; public static int* Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    unsafe static void Main()
    {
        Check(new Holder().Address == null, "instance-pointer-default-null");
        Check(Holder.Global == null, "static-pointer-default-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
