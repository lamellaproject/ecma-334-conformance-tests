/*
Rules: E18-6-2-no-added-params
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int ICount.Count(params int[] values)
Into: int ICount.Count(int[] values)
Csc: CS0466
*/
interface ICount { int Count(int[] values); }
class Counter : ICount { int ICount.Count(params int[] values) { return values.Length; } }
class Program { static void Main() { } }
