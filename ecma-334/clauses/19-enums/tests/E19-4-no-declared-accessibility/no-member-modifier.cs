/*
Rules: E19-4-no-declared-accessibility
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: public Mark = 1
Into: Mark = 1
*/
enum Code { public Mark = 1 }
class Program { static void Main() { } }
