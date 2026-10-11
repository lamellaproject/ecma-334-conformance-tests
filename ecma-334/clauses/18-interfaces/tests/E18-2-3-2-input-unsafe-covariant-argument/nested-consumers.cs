/*
Rules: E18-2-3-2-input-unsafe-covariant-argument
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IBad<out T>
Into: interface IBad<T>
Csc: CS1961
*/
interface ICov<out T> { }
interface IInv<T> { }
interface IBad<out T> { void Covariant(ICov<T> value); void Invariant(IInv<T> value); }
class Program { static void Main() { } }
