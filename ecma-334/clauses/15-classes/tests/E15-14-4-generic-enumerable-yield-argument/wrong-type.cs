/*
Rules: E15-14-4-generic-enumerable-yield-argument
Authority: ECMA-334 7th ed 15.14.4
Version: 7.3
Expected: reject
Mutate: yield return "wrong";
Into: yield return 13;
*/
using System.Collections.Generic;
class Program { static IEnumerable<long> Sequence() { yield return "wrong"; } static void Main() { } }
