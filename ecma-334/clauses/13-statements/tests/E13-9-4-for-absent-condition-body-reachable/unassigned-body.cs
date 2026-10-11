/*
Rules: E13-9-4-for-absent-condition-body-reachable
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: reject
Mutate: for (; ; )
Into: for (; false; )
*/
class Program
{
    static int Read() { int unassigned; for (; ; ) { return unassigned; } return 3; }
    static void Main() { }
}
