/*
Rules: E18-2-4-output-safe-bases
Authority: ECMA-334 7th ed 18.2.4
Version: 7.3
Expected: reject
Mutate: interface IDerived<in T> : IRead<T>
Into: interface IDerived<T> : IRead<T>
Csc: CS1961
*/
interface IRead<out T> { T Read(); }
interface IDerived<in T> : IRead<T> { }
class Program { static void Main() { } }
