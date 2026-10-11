/*
Rules: E9-7-2-1-reference-context-limit; E9-7-2-1-local-referent-declaration; E9-7-2-1-nested-block-distinct-context
Authority: ECMA-334 7th ed 9.7.2.1
Version: 7.3
Expected: reject
Mutate: alias = ref inner;
Into: alias = ref outer;
Csc: CS8374
*/
class Program
{
    static void Main()
    {
        int outer = 4;
        ref int alias = ref outer;
        {
            int inner = 8;
            alias = ref inner;
        }
        alias = 12;
    }
}
