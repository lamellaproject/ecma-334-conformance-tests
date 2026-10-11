/*
Rules: E13-8-3-nonconstant-case-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 3 when flag:
Into: case 3 when false:
*/
class Program
{
    static int Read(int selector, bool flag)
    {
        int unassigned;
        switch (selector) { case 3 when flag: return unassigned; default: return 4; }
    }
    static void Main() { }
}
