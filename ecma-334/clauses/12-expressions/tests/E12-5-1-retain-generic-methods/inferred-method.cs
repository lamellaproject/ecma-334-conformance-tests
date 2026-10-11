/*
Rules: E12-5-1-retain-generic-methods; E12-6-1-generic-inference
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: box.Pick(7)
Into: box.Pick((object)7)
*/
using System;
class Box
{
    public int Pick<T>(T value) { return 13; }
    public int Pick(object value) { return 29; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box(); int result = box.Pick(7);
        Check(result == 13, "zero-explicit-type-arguments-retain-generic-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
