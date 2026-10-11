/*
Rules: E13-9-4-for-condition-end-reachable
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: reject
Mutate: for (; flag; )
Into: for (; true; )
*/
class Program
{
    static int Read(bool flag) { for (; flag; ) { return 3; } }
    static void Main() { }
}
