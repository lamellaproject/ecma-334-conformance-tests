/*
Rules: E18-2-3-2-input-unsafe-array
Authority: ECMA-334 7th ed 18.2.3.2
Version: 7.3
Expected: reject
Mutate: interface IWrite<out T>
Into: interface IWrite<T>
Csc: CS1961
*/
interface IWrite<out T> { void Write(T[] value); }
class Program { static void Main() { } }
