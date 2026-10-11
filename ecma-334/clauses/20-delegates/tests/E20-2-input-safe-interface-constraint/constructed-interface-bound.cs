/*
Rules: E20-2-input-safe-interface-constraint
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/constructed-interface-bound-90c9408530.cs.part
Mutate: delegate void Read<out T, U>() where U : ICell<T>;
Into: delegate void Read<T, U>() where U : ICell<T>;
*/
interface ICell<out T> { }
delegate void Read<out T, U>() where U : ICell<T>;
class Program { static void Main() { } }
