/*
Rules: E7-8-1-static-class-name-context-restriction
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: reject
Mutate: static class Tools { }
Into: class Tools { }
Csc: CS0718
*/
static class Tools { }
class Box<T> { }
class Program { static void Main() { Box<Tools> item = null; } }
