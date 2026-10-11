/*
Rules: E20-2-output-safe-return
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Mutate: delegate T Read<in T>();
Into: delegate T Read<T>();
Csc: CS1961
*/
delegate T Read<in T>();
class Program { static void Main() { } }
