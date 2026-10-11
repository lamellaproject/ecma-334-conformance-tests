/*
Rules: E15-6-2-5-output-assigned-before-read; E15-6-2-5-output-initially-unassigned
Authority: ECMA-334 7th ed 15.6.2.5
Version: 7.3
Expected: reject
Mutate: int observed = value; value = 43;
Into: value = 43; int observed = value;
Csc: CS0269
*/
class Program
{
    static int Write(out int value) { int observed = value; value = 43; return observed; }
    static void Main() { int value = 5; Write(out value); }
}
