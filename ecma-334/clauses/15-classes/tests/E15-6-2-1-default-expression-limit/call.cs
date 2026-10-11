/*
Rules: E15-6-2-1-default-expression-limit
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: int value = Source.Read()
Into: int value = 17
Csc: CS1736
*/
class Source { public static int Read() { return 17; } }
class Holder { public void Touch(int value = Source.Read()) { } }
class Program { static void Main() { } }
