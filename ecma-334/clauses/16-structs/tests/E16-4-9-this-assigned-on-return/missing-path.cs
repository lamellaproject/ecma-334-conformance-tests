/*
Rules: E16-4-9-this-assigned-on-return
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: reject
Mutate: if (choose) Value = 3;
Into: if (choose) Value = 3; else Value = 5;
*/
struct Entry { public int Value; public Entry(bool choose) { if (choose) Value = 3; } }
class Program { static void Main() { } }
