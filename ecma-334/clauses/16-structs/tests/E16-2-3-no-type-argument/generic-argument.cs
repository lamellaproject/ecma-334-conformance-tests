/*
Rules: E16-2-3-no-type-argument
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: Box<Entry> box = new Box<Entry>();
Into: Box<int> box = new Box<int>();
*/
ref struct Entry { }
class Box<T> { }
class Program { static void Main() { Box<Entry> box = new Box<Entry>(); } }
