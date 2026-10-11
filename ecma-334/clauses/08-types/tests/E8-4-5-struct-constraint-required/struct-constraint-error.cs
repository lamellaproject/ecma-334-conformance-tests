/*
Rules: E8-4-5-struct-constraint-required
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: reject
Mutate: Require<int?>();
Into: Require<int>();
*/
class Program { static void Require<T>() where T : struct { } static void Main() { Require<int?>(); } }
