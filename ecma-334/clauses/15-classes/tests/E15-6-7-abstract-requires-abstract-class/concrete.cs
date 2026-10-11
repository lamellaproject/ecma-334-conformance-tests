/*
Rules: E15-6-7-abstract-requires-abstract-class
Authority: ECMA-334 7th ed 15.6.7
Version: 7.3
Expected: reject
Mutate: class Source
Into: abstract class Source
Csc: CS0513
*/
class Source { public abstract int Read(); }
class Program { static void Main() { } }
