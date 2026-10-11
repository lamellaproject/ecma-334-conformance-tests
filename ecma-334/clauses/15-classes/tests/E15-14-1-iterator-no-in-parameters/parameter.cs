/*
Rules: E15-14-1-iterator-no-in-parameters
Authority: ECMA-334 7th ed 15.14.1
Version: 7.3
Expected: reject
Mutate: Sequence(in int n)
Into: Sequence(int n)
*/
using System.Collections.Generic;
class Program { static IEnumerable<int> Sequence(in int n) { yield return n; } static void Main() { } }
