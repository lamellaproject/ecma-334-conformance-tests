/*
Rules: E13-9-3-do-body-reachable
Authority: ECMA-334 7th ed 13.9.3
Version: 7.3
Expected: reject
Mutate: do { return unassigned; } while (false);
Into: while (false) { return unassigned; }
*/
class Program
{
    static int Read()
    {
        int unassigned;
        do { return unassigned; } while (false);
        return 3;
    }
    static void Main() { }
}
