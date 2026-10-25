/*
Rules: E12-23-ed1-constant-binary-operand-types
Authority: ECMA-334 1st ed 14.15
Version: ISO-1
Expected: reject
Version-Witness: tests/E12-23-ed1-constant-binary-operand-types/constant-object-operands.witness.cs.part
Mutate: const bool Same = Left == Right;
Into: static readonly bool Same = Left == Right;
*/
// ECMA-334 1st ed 14.15, p. 177 (PDF p. 191), lines 7-8. A predefined binary operator in a
// constant expression must have operand types from the constant-expression type list.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    const object Left = null;
    const object Right = null;
    const bool Same = Left == Right;
    static int Main()
    {
        Check(Same, "runtime-comparison-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
