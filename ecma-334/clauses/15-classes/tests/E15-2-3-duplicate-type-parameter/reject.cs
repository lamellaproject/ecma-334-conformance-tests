/*
Rules: E15-2-3-duplicate-type-parameter
Authority: ECMA-334 7th ed 15.2.3
Version: 7.3
Expected: reject
Mutate: class Packet<T, T>
Into: class Packet<T, U>
*/
class Packet<T, T> { }
class Program { static void Main() { } }
