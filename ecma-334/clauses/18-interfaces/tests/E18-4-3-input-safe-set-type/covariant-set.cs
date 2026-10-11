/*
Rules: E18-4-3-input-safe-set-type
Authority: ECMA-334 7th ed 18.4.3
Version: 7.3
Expected: reject
Mutate: interface IWrite<out T>
Into: interface IWrite<T>
Csc: CS1961
*/
interface IWrite<out T> { T Value { set; } }
class Program { static void Main() { } }
