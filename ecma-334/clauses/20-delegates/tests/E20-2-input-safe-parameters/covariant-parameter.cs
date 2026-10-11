/*
Rules: E20-2-input-safe-parameters
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: delegate void Write<out T>(T value);
Into: delegate void Write<T>(T value);
Csc: CS1961
*/
delegate void Write<out T>(T value);
class Program { static void Main() { } }
