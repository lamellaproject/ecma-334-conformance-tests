/*
Rules: E9-4-4-13-return-value-output-assigned; E9-4-4-13-return-void-output-assigned
Authority: ECMA-334 7th ed 9.4.4.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: finally { value = 62; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int ByExpression(out int value) { return value = 21; }
    static int ByFinally(out int value) { try { return 8; } finally { value = 62; } }
    static void VoidFinally(out int value) { try { return; } finally { value = 39; } }
    static void Main()
    {
        int cell;
        int result = ByExpression(out cell);
        Check(result == 21 && cell == 21, "output-assigned-during-return-expression");
        result = ByFinally(out cell);
        Check(result == 8 && cell == 62, "output-assigned-in-finally-after-return-expression");
        VoidFinally(out cell);
        Check(cell == 39, "output-assigned-in-finally-after-void-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
