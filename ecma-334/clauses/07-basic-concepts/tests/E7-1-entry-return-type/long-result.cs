/*
Rules: E7-1-entry-return-type
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: static long Main()
Into: static int Main()
*/
class Program
{
    static long Main() { return 0; }
}
