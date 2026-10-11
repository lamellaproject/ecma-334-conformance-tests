/*
Rules: E12-11-overload-left-type
Authority: ECMA-334 7th ed 12.11
Version: 7.3
Expected: reject
Mutate: operator <<(Other x, int count)
Into: operator <<(Number x, int count)
*/
class Other { }
class Number { public static Number operator <<(Other x, int count) { return new Number(); } }
class Program { static void Main() { } }
