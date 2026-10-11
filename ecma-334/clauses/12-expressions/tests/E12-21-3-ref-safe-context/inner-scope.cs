/*
Rules: E12-21-3-ref-safe-context
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: alias = ref inner
Into: alias = ref first
Csc: CS8374
*/
class Program
{
    static void Main()
    {
        int first = 3;
        ref int alias = ref first;
        { int inner = 7; alias = ref inner; }
    }
}
