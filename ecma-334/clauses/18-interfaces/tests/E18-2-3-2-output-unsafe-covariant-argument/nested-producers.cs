/*
Rules: E18-2-3-2-output-unsafe-covariant-argument
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IBad<in T>
Into: interface IBad<T>
Csc: CS1961
*/
interface ICov<out T> { }
interface IInv<T> { }
interface IBad<in T> { ICov<T> Covariant(); IInv<T> Invariant(); }
class Program { static void Main() { } }
