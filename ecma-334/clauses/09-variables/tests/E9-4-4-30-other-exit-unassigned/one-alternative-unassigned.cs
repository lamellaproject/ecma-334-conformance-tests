/*
Rules: E9-4-4-30-other-exit-unassigned
Authority: ECMA-334 7th ed 9.4.4.30
Version: 7.3
Expected: reject
Mutate: (cell = 18) : 41
Into: (cell = 18) : (cell = 41)
Csc: CS0165
*/
class Program
{
    static int Read(bool gate) { int cell; int result = gate ? (cell = 18) : 41; return cell; }
    static void Main() { Read(false); }
}
