/*
Rules: E18-4-2-input-safe-interface-constraint
Authority: ECMA-334 7th ed 18.4.2
Version: 7.3
Expected: reject
Mutate: interface IBound<out T>
Into: interface IBound<T>
Csc: CS1961
*/
interface IRead<out T> { T Read(); }
interface IBound<out T> { void Read<U>() where U : IRead<T>; }
class Program { static void Main() { } }
