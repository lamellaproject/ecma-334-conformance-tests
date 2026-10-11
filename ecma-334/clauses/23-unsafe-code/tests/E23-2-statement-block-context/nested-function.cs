/*
Rules: E23-2-statement-block-context; E23-2-form-statement; E23-2-nested-local-function-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe {
Into: {
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe {
            int value = 31;
            int Read(int* p) { return *p; }
            Check(Read(&value) == 31, "local-function-in-unsafe-block");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
