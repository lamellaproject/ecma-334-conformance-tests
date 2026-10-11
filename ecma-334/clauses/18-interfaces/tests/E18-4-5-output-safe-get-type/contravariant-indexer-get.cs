/*
Rules: E18-4-5-output-safe-get-type
Authority: ECMA-334 7th ed 18.4.5
Version: 7.3
Expected: reject
Mutate: interface IRead<in T>
Into: interface IRead<T>
Csc: CS1961
*/
interface IRead<in T> { T this[int index] { get; } }
class Program { static void Main() { } }
