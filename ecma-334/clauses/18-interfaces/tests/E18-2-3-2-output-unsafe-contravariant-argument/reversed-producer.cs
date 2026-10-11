/*
Rules: E18-2-3-2-output-unsafe-contravariant-argument
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IBad<out T>
Into: interface IBad<T>
Csc: CS1961
*/
interface IContra<in T> { }
interface IInv<T> { }
interface IBad<out T> { IContra<T> Contravariant(); IInv<T> Invariant(); }
class Program { static void Main() { } }
