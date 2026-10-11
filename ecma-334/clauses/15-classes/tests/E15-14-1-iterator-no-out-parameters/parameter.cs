/*
Rules: E15-14-1-iterator-no-out-parameters
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Mutate: Sequence(out int n)
Into: Sequence(int n)
*/
using System.Collections.Generic;
class Program { static IEnumerable<int> Sequence(out int n) { n = 13; yield return n; } static void Main() { } }
