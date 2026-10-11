/*
Rules: E18-4-2-output-safe-ref-parameter
Authority: ECMA-334 7th ed 18.4.2
Version: 7.3
Expected: reject
Mutate: interface IRead<in T>
Into: interface IRead<T>
Csc: CS1961
*/
interface IRead<in T> { void Read(ref T value); }
class Program { static void Main() { } }
