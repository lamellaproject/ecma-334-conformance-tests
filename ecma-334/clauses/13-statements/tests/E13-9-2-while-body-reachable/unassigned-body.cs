/*
Rules: E13-9-2-while-body-reachable
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: reject
Mutate: while (flag)
Into: while (false)
*/
class Program
{
    static int Read(bool flag) { int unassigned; while (flag) { return unassigned; } return 3; }
    static void Main() { }
}
