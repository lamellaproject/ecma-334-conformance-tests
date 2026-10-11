/*
Rules: E18-2-3-2-input-unsafe-covariant; E18-2-3-2-no-input-unsafe-position; E18-4-2-input-safe-parameters
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IWrite<out T>
Into: interface IWrite<T>
Csc: CS1961
*/
interface IWrite<out T> { void Write(T value); }
class Program { static void Main() { } }
