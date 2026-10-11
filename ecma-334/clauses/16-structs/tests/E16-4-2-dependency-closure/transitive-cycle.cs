/*
Rules: E16-4-2-dependency-closure; E16-4-2-no-circular-field-dependency
Authority: ECMA-334 7th ed 16.4.2
Version: 7.3
Expected: reject
Mutate: public First Back;
Into: public int Back;
*/
struct First { public Second Next; }
struct Second { public Third Next; }
struct Third { public First Back; }
class Program { static void Main() { } }
