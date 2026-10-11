/*
Rules: E18-4-5-input-safe-parameters
Authority: ECMA-334 7th ed 18.4.5
Version: 7.3
Expected: reject
Mutate: interface IRead<out T>
Into: interface IRead<T>
Csc: CS1961
*/
interface IRead<out T> { int this[T index] { get; } }
class Program { static void Main() { } }
