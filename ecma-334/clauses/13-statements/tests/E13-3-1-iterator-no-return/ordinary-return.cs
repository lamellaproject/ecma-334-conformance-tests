/*
Rules: E13-3-1-iterator-no-return
Authority: ECMA-334 7th ed 13.3.1
Version: 7.3
Expected: reject
Mutate: return;
Into: yield break;
*/
using System.Collections.Generic;
class Program
{
    static IEnumerable<int> Values() { yield return 6; return; }
    static void Main() { }
}
