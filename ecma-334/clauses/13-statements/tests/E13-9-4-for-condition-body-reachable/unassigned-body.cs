/*
Rules: E13-9-4-for-condition-body-reachable
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: reject
Mutate: for (; flag; )
Into: for (; false; )
*/
class Program
{
    static int Read(bool flag) { int unassigned; for (; flag; ) { return unassigned; } return 3; }
    static void Main() { }
}
