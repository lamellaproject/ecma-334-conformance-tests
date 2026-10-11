/*
Rules: E13-8-2-if-first-reachable
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: reject
Mutate: if (flag)
Into: if (false)
*/
class Program
{
    static int Read(bool flag)
    {
        int value;
        if (flag) return value;
        return 3;
    }
    static void Main() { }
}
