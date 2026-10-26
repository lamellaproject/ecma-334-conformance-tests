/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: Sweep(out int first, ref byte second)
Into: Sweep(out long first, ref byte second)
*/
class ModeVector
{
    static void Sweep(ref int first, out byte second) { second = 4; }
    static void Sweep(out int first, ref byte second) { first = 15; }
    static void Main() {}
}
