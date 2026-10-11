/*
Rules: E20-2-output-safe-ref-parameter
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: delegate void Edit<in T>(ref T value);
Into: delegate void Edit<T>(ref T value);
Csc: CS1961
*/
delegate void Edit<in T>(ref T value);
class Program { static void Main() { } }
