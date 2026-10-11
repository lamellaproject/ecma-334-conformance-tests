/*
Rules: E16-3-fixed-buffer-unsafe-only
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: reject
Mutate: struct Entry
Into: unsafe struct Entry
*/
struct Entry { public fixed int Items[3]; }
class Program { static void Main() { } }
