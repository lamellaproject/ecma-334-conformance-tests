/*
Rules: E12-4-1-operand-order; E12-4-1-operator-order; E12-4-2-precedence-order; E12-4-2-grammar-precedence
Authority: ECMA-334 7th ed 12.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read(1, 4) - Read(2, 3) * Read(3, 5)
Into: Read(1, 4) * Read(2, 3) - Read(3, 5)
*/
using System;
class Program
{
    static int checks, failures, trace;
    static int Read(int tag, int value) { trace = trace * 10 + tag; return value; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Read(1, 4) - Read(2, 3) * Read(3, 5);
        Check(result == -11, "multiply-before-subtract");
        Check(trace == 123, "operands-left-to-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
