/*
Rules: E18-4-1-unique-type-parameter
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: interface IPair<T, T>
Into: interface IPair<T, U>
Csc: CS0692
*/
interface IPair<T, T> { }
class Program { static void Main() { } }
