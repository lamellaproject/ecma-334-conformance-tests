/*
Rules: E16-2-3-no-iterator-use
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/iterator-local-ae3621b756.cs.part
Mutate: ref struct Entry
Into: struct Entry
*/
using System.Collections.Generic;
ref struct Entry { public int Value; }
class Program
{
    static int Read(Entry item) { return item.Value; }
    static IEnumerable<int> Values()
    {
        { Entry item = default(Entry); item.Value = 1; Read(item); }
        yield return 3;
    }
    static void Main() { }
}
