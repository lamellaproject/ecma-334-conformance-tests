/*
Rules: E16-4-3-no-base-class
Authority: ECMA-334 7th ed 16.4.3
Version: 7.3
Expected: reject
Mutate: struct Entry : Parent
Into: struct Entry
*/
class Parent { }
struct Entry : Parent { }
class Program { static void Main() { } }
