/*
Rules: E12-6-1-no-explicit-static-constructor
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: reject
Mutate: Box.Box();
Into: Box.Touch();
*/
class Box { static Box() { } public static void Touch() { } }
class Program { static void Main() { Box.Box(); } }
