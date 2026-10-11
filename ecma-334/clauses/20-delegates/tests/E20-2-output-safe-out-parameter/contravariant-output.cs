/*
Rules: E20-2-output-safe-out-parameter
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: delegate void Read<in T>(out T value);
Into: delegate void Read<T>(out T value);
Csc: CS1961
*/
delegate void Read<in T>(out T value);
class Program { static void Main() { } }
