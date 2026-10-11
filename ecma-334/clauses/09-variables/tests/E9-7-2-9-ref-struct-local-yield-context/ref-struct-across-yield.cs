/*
Rules: E9-7-2-9-ref-struct-local-yield-context
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref struct Cell
Into: struct Cell
Csc: CS4007
*/
using System.Collections.Generic;
ref struct Cell { public int Value; }
class Program
{
    static IEnumerable<int> Values()
    {
        Cell cell = new Cell { Value = 70 };
        yield return 1;
        yield return cell.Value;
    }
    static void Main() { }
}
