/*
Rules: E23-6-1-pointer-expression-unsafe
Authority: ECMA-334 7th ed 23.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* selected = choose ? &left : &right;
Into: int* selected = choose ? &right : &left;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int left = 41, right = 9;
        bool choose = true;
        int* selected = choose ? &left : &right;
        Check(*selected == 41, "unsafe-pointer-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
