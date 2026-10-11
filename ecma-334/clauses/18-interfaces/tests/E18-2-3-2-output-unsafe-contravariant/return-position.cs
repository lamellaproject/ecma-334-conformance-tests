/*
Rules: E18-2-3-2-output-unsafe-contravariant; E18-2-3-2-no-output-unsafe-position; E18-4-2-output-safe-return
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IRead<in T>
Into: interface IRead<T>
Csc: CS1961
*/
interface IRead<in T> { T Read(); }
class Program { static void Main() { } }
