/*
Rules: E21-5-checked-overflow; E21-5-overflow-base; E21-5-arithmetic-base
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: checked(value + 1)
Into: unchecked(value + 1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = int.MaxValue;
        bool rightType = false, arithmeticBase = false;
        try { int result = checked(value + 1); }
        catch (OverflowException caught)
        {
            rightType = true;
            ArithmeticException root = caught;
            arithmeticBase = root == caught;
        }
        catch (Exception) { }
        Check(rightType, "checked-overflow-exception");
        Check(arithmeticBase, "overflow-is-arithmetic-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
