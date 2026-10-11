/*
Rules: E13-6-2-4-iterator-no-ref-local
Authority: ECMA-334 7th ed 13.6.2.4
Version: 7.3
Expected: reject
Mutate: ref int alias = ref value;
Into: int alias = value;
*/
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Values() { int value = 6; ref int alias = ref value; yield return alias; }
    static void Main() { }
}
