/*
Rules: E16-2-3-no-iterator-use
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry
Into: struct Entry
*/
using System.Collections.Generic;
ref struct Entry { public int Value; }
class Program
{
    static IEnumerable<int> Values(Entry item) { yield return item.Value; }
    static void Main() { }
}
