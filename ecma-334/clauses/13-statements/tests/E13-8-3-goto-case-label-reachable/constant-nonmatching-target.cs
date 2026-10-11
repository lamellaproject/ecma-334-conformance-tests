/*
Rules: E13-8-3-goto-case-label-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: goto case 4;
Into: return 3;
*/
class Program
{
    static int Read()
    {
        int unassigned;
        switch (3) { case 3: goto case 4; case 4: return unassigned; default: return 5; }
    }
    static void Main() { }
}
