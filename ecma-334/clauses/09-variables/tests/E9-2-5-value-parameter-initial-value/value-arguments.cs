/*
Rules: E9-2-5-value-parameter-initial-value; E9-2-5-value-parameter-category; E9-2-5-value-parameter-lifetime-start; E9-2-5-value-parameter-initially-assigned; E9-4-2-value-parameter-assigned
Authority: ECMA-334 7th ed 9.2.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static int Read(int value) { return value; }
Into: static int Read(int value) { return 0; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int value) { return value; }
    static int Change(int value) { value = 91; return value; }
    static void Main()
    {
        int argument = 34;
        Check(Read(argument) == 34 && Read(72) == 72, "new-parameter-initialized-on-each-call");
        Check(Change(argument) == 91, "parameter-is-writable-storage");
        Check(argument == 34, "value-parameter-is-separate-from-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
