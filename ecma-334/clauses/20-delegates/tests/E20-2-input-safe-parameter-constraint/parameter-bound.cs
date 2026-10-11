/*
Rules: E20-2-input-safe-parameter-constraint
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/parameter-bound-9816a6d47e.cs.part
Mutate: delegate void Read<out T, U>() where U : T;
Into: delegate void Read<T, U>() where U : T;
*/
delegate void Read<out T, U>() where U : T;
class Program { static void Main() { } }
