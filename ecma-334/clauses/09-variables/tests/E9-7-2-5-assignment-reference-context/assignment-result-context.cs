/*
Rules: E9-7-2-5-assignment-reference-context
Authority: ECMA-334 7th ed 9.7.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: alias = ref second
Into: alias = ref local
*/
using System;
class Program
{
    static int checks, failures;
    static int first = 31, second = 35;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Select()
    {
        int local = 39;
        ref int alias = ref local;
        // 9.7.2.5, p. 114: "ref" in "all ref operands" is the
        // keyword (code font in the PDF), so for = ref e only e counts.
        return ref (alias = ref second);
    }
    static void Main()
    {
        ref int selected = ref Select();
        selected = 43;
        Check(second == 43, "assignment-result-refers-to-right-operand");
        Check(first == 31, "other-static-field-unchanged");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
