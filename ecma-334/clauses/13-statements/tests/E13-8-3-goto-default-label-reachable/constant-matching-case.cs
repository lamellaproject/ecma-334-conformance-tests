/*
Rules: E13-8-3-goto-default-label-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: goto default;
Into: return 3;
*/
class Program
{
    static int Read()
    {
        int unassigned;
        switch (3) { case 3: goto default; default: return unassigned; }
    }
    static void Main() { }
}
