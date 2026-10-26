/*
Rules: E23-2-ed2-static-unsafe-order
Authority: ECMA-334 2nd ed 25.1
Version: ISO-1
Expected: run
Stdout: OK 1
Mutate: static unsafe PointerWindow()
Into: static PointerWindow()
*/
using System;
class PointerWindow
{
    public static int Observed;
    static unsafe PointerWindow()
    {
        int cell = 52;
        int* pointer = &cell;
        Observed = *pointer;
    }
}
class UnsafeConstructorOrder
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
        Check(PointerWindow.Observed == 52, "static-unsafe-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
