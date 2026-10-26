/*
Rules: E12-10-4-ed2-decimal-remainder-scale
Authority: ECMA-334 2nd ed 14.7.3
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: decimal result = amount % unit;
Into: decimal result = 2.1m;
*/
using System;
class RemainderScale
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        decimal amount = 14.1000m;
        decimal unit = 3.0m;
        decimal result = amount % unit;
        int flags = decimal.GetBits(result)[3];
        Check(result == 2.1m, "decimal-remainder-value");
        Check(((flags >> 16) & 255) == 4, "decimal-remainder-scale");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
