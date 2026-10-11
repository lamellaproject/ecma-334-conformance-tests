/*
Rules: E18-6-3-uniqueness-add-bases
Authority: ECMA-334 7th ed 18.6.3
Version: 7.3
Expected: reject
Mutate: class Both<T> : ILeft<T>, IRight
Into: class Both<T> : ILeft<T>
Csc: CS0695
*/
interface ICell<T> { }
interface ILeft<T> : ICell<T> { }
interface IRight : ICell<int> { }
class Both<T> : ILeft<T>, IRight { }
class Program { static void Main() { } }
