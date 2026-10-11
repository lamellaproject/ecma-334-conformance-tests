/*
Rules: E16-4-2-nonnullable
Authority: ECMA-334 7th ed 16.4.2
Version: 7.3
Expected: reject
Mutate: Entry item = null;
Into: Entry? item = null;
*/
struct Entry { }
class Program { static void Main() { Entry item = null; } }
