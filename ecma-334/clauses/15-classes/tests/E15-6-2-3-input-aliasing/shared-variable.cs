/*
Rules: E15-6-2-3-input-aliasing; E15-6-2-3-input-parameter-classification; E15-6-2-3-input-reference-initialization; E15-6-2-3-input-existing-variable; E15-6-2-3-input-explicit-argument; E15-6-2-3-input-definitely-assigned
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: in int first, in int second, ref int writable
Into: int first, in int second, ref int writable
*/
using System;
class Program
{
    static int Change(in int first, in int second, ref int writable)
    {
        int before = first + second;
        writable = 19;
        return first * 1000 + second * 100 + before;
    }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 5;
        Check(Change(in value, in value, ref value) == 20910, "input-references-read-current-shared-storage");
        Check(value == 19, "writable-alias-modifies-existing-argument-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
