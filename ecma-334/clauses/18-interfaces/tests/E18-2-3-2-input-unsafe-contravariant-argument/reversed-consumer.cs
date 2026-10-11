/*
Rules: E18-2-3-2-input-unsafe-contravariant-argument
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IBad<in T>
Into: interface IBad<T>
Csc: CS1961
*/
interface IContra<in T> { }
interface IInv<T> { }
interface IBad<in T> { void Contravariant(IContra<T> value); void Invariant(IInv<T> value); }
class Program { static void Main() { } }
