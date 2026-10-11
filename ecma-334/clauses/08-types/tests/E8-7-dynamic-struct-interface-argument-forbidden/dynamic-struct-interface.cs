/*
Rules: E8-7-dynamic-struct-interface-argument-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: ITag<Box<dynamic>>
Into: ITag<Box<object>>
*/
interface ITag<T> { }
class Box<T> { }
struct Receiver : ITag<Box<dynamic>> { }
class Program { static void Main() { } }
