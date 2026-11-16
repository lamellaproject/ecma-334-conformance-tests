/*
Rules: E7-7-1-method-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Adjust(int operand)
Into: Adjust(int renamed)
*/
using System;
class Program
{
    static int checks, failures;
    static int input = -11;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Adjust(int operand)
    {
        if (operand < 0)
        {
            int magnitude = -operand;
            return magnitude + operand;
        }
        return operand * 3;
    }
    static void Main()
    {
        Check(Adjust(input) == 0, "parameter-in-nested-block");
        input = 13;
        Check(Adjust(input) == 39, "parameter-in-final-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
