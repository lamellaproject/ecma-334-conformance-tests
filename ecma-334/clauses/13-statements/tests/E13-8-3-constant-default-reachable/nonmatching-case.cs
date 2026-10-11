/*
Rules: E13-8-3-constant-default-reachable
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: case 4:
Into: case 3:
*/
class Program
{
    static int Read()
    {
        int unassigned;
        switch (3) { case 4: return 4; default: return unassigned; }
    }
    static void Main() { }
}
