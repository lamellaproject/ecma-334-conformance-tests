/*
Rules: E13-6-2-4-iterator-no-ref-struct-local
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/iterator-ref-struct-1f8f1b451c.cs.part
Mutate: ref struct Token
Into: struct Token
*/
using System.Collections.Generic;
ref struct Token { public int Value; }
class Program
{
    static IEnumerable<int> Values() { Token item = default(Token); yield return item.Value; }
    static void Main() { }
}
