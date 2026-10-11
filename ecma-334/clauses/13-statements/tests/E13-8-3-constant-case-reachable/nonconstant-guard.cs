/*
Rules: E13-8-3-constant-case-reachable; E13-8-3-switch-section-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 3 when flag:
Into: case 3 when false:
*/
class Program
{
    static int Read(bool flag)
    {
        int unassigned;
        switch (3) { case 3 when flag: return unassigned; default: return 4; }
    }
    static void Main() { }
}
