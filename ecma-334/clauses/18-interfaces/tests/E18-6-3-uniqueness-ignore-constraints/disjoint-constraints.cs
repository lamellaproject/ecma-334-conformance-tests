/*
Rules: E18-6-3-uniqueness-ignore-constraints
Authority: ECMA-334 7th ed 18.6.3
Version: 7.3
Expected: reject
Mutate: interface IBoth<T, U> : ICell<T>, ICell<U>
Into: interface IBoth<T, U> : ICell<T>, IOther<U>
Csc: CS0695
*/
interface ICell<T> { }
interface IOther<T> { }
interface IBoth<T, U> : ICell<T>, ICell<U> where T : class where U : struct { }
class Program { static void Main() { } }
