/*
Rules: E9-4-4-25-ed1-assignment-right-entry
Authority: ECMA-334 1st ed 12.3.3.22
Version: ISO-1
Expected: reject
Version-Witness: tests/E9-4-4-25-ed1-assignment-right-entry/receiver-out-flow.witness.cs.part
Mutate: int token;
Into: int token = 0;
*/
// ECMA-334 1st ed 12.3.3.22, p. 109 (PDF p. 123), lines 17-20. The definite-assignment
// state before the right operand of a simple assignment is the state before the whole
// assignment expression, so an out assignment while evaluating a complex left operand
// cannot make that right operand definitely assigned.
class Stamp
{
    public static int Saved;
    public Stamp(out int token) { token = 17; }
    public int Value { set { Saved = value; } }
}

class Entry
{
    static void Main()
    {
        int token;
        new Stamp(out token).Value = token;
        System.Console.WriteLine(Stamp.Saved);
    }
}
