/*
Rules: E9-7-2-9-ref-struct-parameter-iterator-argument
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
    static IEnumerable<int> Values(Cell cell) { yield return cell.Value; }
    static void Main() { }
}
