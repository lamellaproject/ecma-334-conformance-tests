/*
Rules: E18-4-3-output-safe-get-type
Authority: ECMA-334 7th ed 18.4.3
Version: 7.3
Expected: reject
Mutate: interface IRead<in T>
Into: interface IRead<T>
Csc: CS1961
*/
interface IRead<in T> { T Value { get; } }
class Program { static void Main() { } }
