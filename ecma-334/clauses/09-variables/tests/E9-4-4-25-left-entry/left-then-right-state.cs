/*
Rules: E9-4-4-25-left-entry; E9-4-4-25-right-entry; E9-4-4-25-other-assignment-exit
Authority: ECMA-334 7th ed 9.4.4.25
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: slots[index = 1]
Into: slots[1]
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int index, cell;
        int[] slots = new int[2];
        slots[index = 1] = (cell = index + 6);
        Check(slots[0] == 0 && slots[1] == 7, "left-expression-assignment-reaches-right-expression");
        Check(index == 1 && cell == 7, "nontarget-state-propagated-from-right-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
