/*
Rules: E18-4-2-input-safe-class-constraint
Authority: ECMA-334 7th ed 18.4.2
Version: 7.3
Expected: reject
Mutate: interface IBound<out T>
Into: interface IBound<T>
Csc: CS1961
*/
// 18.2.3.2, p. 489 omits constructed classes from input-unsafety. That omission
// is incorrect because classes are invariant: Cell<T> cannot covary to Cell<object>.
// This test follows the variance-safety intent for the class bound in 18.4.2, p. 492.
class Cell<T> { public T Value; }
interface IBound<out T> { void Read<U>() where U : Cell<T>; }
class Program { static void Main() { } }
