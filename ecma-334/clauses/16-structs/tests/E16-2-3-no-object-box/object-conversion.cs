/*
Rules: E16-2-3-no-object-box; E16-2-3-no-object-conversion
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: ref struct Entry
Into: struct Entry
*/
ref struct Entry { }
class Program { static void Main() { Entry item = default(Entry); object boxed = item; } }
