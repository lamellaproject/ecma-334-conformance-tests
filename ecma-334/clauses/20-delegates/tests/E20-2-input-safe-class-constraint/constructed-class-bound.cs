/*
Rules: E20-2-input-safe-class-constraint
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/constructed-class-bound-7bb1d00d59.cs.part
Mutate: delegate void Read<out T, U>() where U : Cell<T>;
Into: delegate void Read<T, U>() where U : Cell<T>;
*/
// 18.2.3.2, p. 489 omits constructed classes from input-unsafety. That omission
// is incorrect because classes are invariant: Cell<T> cannot covary to Cell<object>.
// This test follows the variance-safety intent for the class bound in 20.2, p. 518.
class Cell<T> { }
delegate void Read<out T, U>() where U : Cell<T>;
class Program { static void Main() { } }
