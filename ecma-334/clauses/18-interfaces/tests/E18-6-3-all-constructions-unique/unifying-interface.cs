/*
Rules: E18-6-3-all-constructions-unique; E18-6-3-uniqueness-direct-list
Authority: ECMA-334 7th ed 18.6.3
Version: 7.3
Expected: reject
Mutate: interface IPair<T, U> : ICell<T>, ICell<U>
Into: interface IPair<T, U> : ICell<T>, IOther<U>
Csc: CS0695
*/
interface ICell<T> { }
interface IOther<T> { }
interface IPair<T, U> : ICell<T>, ICell<U> { }
class Program { static void Main() { } }
