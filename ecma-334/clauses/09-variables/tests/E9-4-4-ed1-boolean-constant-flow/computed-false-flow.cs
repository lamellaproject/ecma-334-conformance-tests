/*
Rules: E9-4-4-ed1-boolean-constant-flow
Authority: ECMA-334 1st ed 12.3.3
Version: ISO-1
Expected: reject
Version-Witness: tests/E9-4-4-ed1-boolean-constant-flow/computed-false-flow.witness.cs.part
Mutate: int token;
Into: int token = 0;
*/
// ECMA-334 1st ed 12.3.3, p. 108 (PDF p. 122), lines 17-40. An unassigned local in the
// right operand of a false conditional-and expression still causes a definite-assignment
// error.
class Entry
{
    static void Main()
    {
        int token;
        bool signal = (2 > 3) && token == 7;
        System.Console.WriteLine(signal ? 0 : 1);
    }
}
