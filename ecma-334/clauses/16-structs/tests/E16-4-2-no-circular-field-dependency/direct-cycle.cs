/*
Rules: E16-4-2-no-circular-field-dependency; E16-4-2-direct-dependency
Authority: ECMA-334 7th ed 16.4.2
Version: 7.3
Expected: reject
Mutate: public Entry Child;
Into: public int Child;
*/
struct Entry { public Entry Child; }
class Program { static void Main() { } }
