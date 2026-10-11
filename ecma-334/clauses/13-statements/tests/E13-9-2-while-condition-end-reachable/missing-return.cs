/*
Rules: E13-9-2-while-condition-end-reachable
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: reject
Mutate: while (flag)
Into: while (true)
*/
class Program
{
    static int Read(bool flag) { while (flag) { return 3; } }
    static void Main() { }
}
