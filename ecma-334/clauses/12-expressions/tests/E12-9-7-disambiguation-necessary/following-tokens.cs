/*
Rules: E12-9-7-disambiguation-necessary; E12-9-7-disambiguation-type-only; E12-9-7-disambiguation-following-token
Authority: ECMA-334 7th ed 12.9.7
Version: 7.3
Expected: run
Stdout: OK 8
Mutate: (Number)-1
Into: (int)-1
*/
using System;
using Number = System.Int32;
using Flag = System.Boolean;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int Number = 8; int source = 3;
        Check((Number)-1 == 7, "minus-after-ambiguous-name-is-expression");
        Check((Number)+1 == 9, "plus-after-ambiguous-name-is-expression");
        Check((int)-source == -3, "type-only-grammar");
        Check((Number)~source == -4, "complement-starts-cast-operand");
        Check((Flag)!true == false, "not-starts-cast-operand");
        Check((Number)(source) == 3, "parenthesis-starts-cast-operand");
        Check((Number)source == 3 && (Number)4 == 4, "identifier-and-literal-start-cast-operand");
        Check((Number)default(int) == 0, "keyword-starts-cast-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
