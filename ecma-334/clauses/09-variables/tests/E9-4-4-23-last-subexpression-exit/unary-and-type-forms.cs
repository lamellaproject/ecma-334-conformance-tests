/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 10
Mutate: int parenthesized = ((cell = 27));
Into: int parenthesized = ((27));
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell;
        int parenthesized = ((cell = 27));
        Check(parenthesized == 27 && cell == 27, "parentheses-preserve-assignment");
        int checkedResult = checked(cell = 29);
        Check(checkedResult == 29 && cell == 29, "checked-preserves-assignment");
        int uncheckedResult = unchecked(cell = 31);
        Check(uncheckedResult == 31 && cell == 31, "unchecked-preserves-assignment");
        int prefix = ++cell;
        Check(prefix == 32 && cell == 32, "prefix-increment-preserves-state");
        int postfix = cell++;
        Check(postfix == 32 && cell == 33, "postfix-increment-preserves-state");
        prefix = --cell;
        Check(prefix == 32 && cell == 32, "prefix-decrement-preserves-state");
        postfix = cell--;
        Check(postfix == 32 && cell == 31, "postfix-decrement-preserves-state");
        object receiver;
        bool isString = (receiver = "tag") is string;
        Check(isString && (string)receiver == "tag", "is-preserves-operand-assignment");
        string asString = (receiver = "stamp") as string;
        Check(asString == "stamp" && receiver == asString, "as-preserves-operand-assignment");
        Func<int> original = () => cell;
        Func<int> captured;
        Func<int> created = new Func<int>(captured = original);
        Check(created() == 31 && captured() == 31, "delegate-creation-operand-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
