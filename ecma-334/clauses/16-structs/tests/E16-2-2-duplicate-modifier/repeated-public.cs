/*
Rules: E16-2-2-duplicate-modifier
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Mutate: public public struct Entry
Into: public struct Entry
*/
public public struct Entry { }
class Program { static void Main() { } }
