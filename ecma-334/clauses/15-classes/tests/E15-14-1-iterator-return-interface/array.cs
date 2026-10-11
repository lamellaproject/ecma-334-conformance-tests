/*
Rules: E15-14-1-iterator-return-interface
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Mutate: static int[] Sequence()
Into: static IEnumerable<int> Sequence()
*/
using System.Collections.Generic;
class Program { static int[] Sequence() { yield return 13; } static void Main() { } }
