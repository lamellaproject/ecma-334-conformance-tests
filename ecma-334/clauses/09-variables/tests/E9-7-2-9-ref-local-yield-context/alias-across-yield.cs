/*
Rules: E9-7-2-9-ref-local-yield-context
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref int alias = ref cell;
Into: int alias = cell;
Csc: CS8370
*/
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Values()
    {
        int cell = 62;
        ref int alias = ref cell;
        yield return 1;
        yield return alias;
    }
    static void Main() { }
}
