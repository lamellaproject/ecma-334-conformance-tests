/*
Rules: E16-2-1-containing-arguments
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: reject
Mutate: Box.Entry item;
Into: Box<int>.Entry item;
*/
class Box<T> { public struct Entry { } }
class Program { static void Main() { Box.Entry item; } }
