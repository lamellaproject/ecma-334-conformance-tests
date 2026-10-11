/*
Rules: E13-8-2-if-second-reachable
Authority: ECMA-334 7th ed 13.8.2
Version: 7.3
Expected: reject
Mutate: if (flag)
Into: if (true)
*/
class Program
{
    static int Read(bool flag)
    {
        int value;
        if (flag) return 3;
        else return value;
    }
    static void Main() { }
}
