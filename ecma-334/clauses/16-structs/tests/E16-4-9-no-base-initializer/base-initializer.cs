/*
Rules: E16-4-9-no-base-initializer
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: reject
Mutate: : base()
Into: : this()
*/
struct Entry { public Entry(int unused) : base() { } }
class Program { static void Main() { } }
