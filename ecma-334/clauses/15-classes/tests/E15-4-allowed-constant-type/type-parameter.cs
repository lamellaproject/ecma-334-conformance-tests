/*
Rules: E15-4-allowed-constant-type
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: public const T Empty = default(T);
Into: public static readonly T Empty = default(T);
Csc: CS1959
*/
class Limits<T> { public const T Empty = default(T); }
class Program { static void Main() { int value = Limits<int>.Empty; } }
