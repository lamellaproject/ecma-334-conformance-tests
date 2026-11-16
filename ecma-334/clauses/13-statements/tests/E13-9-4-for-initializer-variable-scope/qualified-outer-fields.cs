/*
Rules: E13-9-4-for-initializer-variable-scope; E13-9-4-form-for-variable-initializer; E13-9-4-for-initializer-order
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: step = cursor + 1
Into: step = cursor + 2
*/
using System;
class Program
{
    static int checks, failures, cursor = 19, step = 23;
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        int sum = 0;
        for (int cursor = 2, step = cursor + 1; cursor < 9; cursor += step)
            sum += cursor;
        Check(sum == 15, "initializer-order-and-entire-loop-scope");
        Check(Program.cursor == 19 && Program.step == 23, "qualified-fields-outside-loop");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
