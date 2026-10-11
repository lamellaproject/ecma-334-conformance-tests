/*
Rules: E18-4-4-input-safe-event-type
Authority: ECMA-334 7th ed 18.4.4
Version: 7.3
Expected: reject
Mutate: interface ISource<out T>
Into: interface ISource<T>
Csc: CS1961
*/
delegate T Notice<out T>();
interface ISource<out T> { event Notice<T> Ready; }
class Program { static void Main() { } }
