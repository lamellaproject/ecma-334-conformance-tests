/*
Rules: E21-5-divide-by-zero; E21-5-divide-by-zero-base; E21-5-arithmetic-base
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int divisor = 0
Into: int divisor = 1
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int numerator = 19; int divisor = 0;
        bool rightType = false, arithmeticBase = false;
        try { int result = numerator / divisor; }
        catch (DivideByZeroException caught)
        {
            rightType = true;
            ArithmeticException root = caught;
            arithmeticBase = root == caught;
        }
        catch (Exception) { }
        Check(rightType, "integral-zero-divisor-exception");
        Check(arithmeticBase, "divide-by-zero-is-arithmetic-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
