/*
Rules: E6-5-5-selected-lexical-conformance
Authority: ECMA-334 7th ed 6.5.5
Version: 7.3
Expected: reject
Mutate: 17$
Into: 17
*/
class Program
{
    static void Main()
    {
#if true
        int amount = 17$;
#endif
    }
}
