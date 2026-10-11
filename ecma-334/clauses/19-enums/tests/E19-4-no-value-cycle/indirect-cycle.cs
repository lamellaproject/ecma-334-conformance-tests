/*
Rules: E19-4-no-value-cycle
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: Last = First
Into: Last = 1
*/
enum Code { First = Middle, Middle = Last, Last = First }
class Program { static void Main() { } }
