/*
Rules: E15-6-8-external-semicolon-body
Authority: ECMA-334 7th ed 15.6.8
Version: 7.3
Expected: reject
Mutate: public static extern int Read() => 97;
Into: public static extern int Read();
Csc: CS0179
*/
class External { public static extern int Read() => 97; }
class Program { static void Main() { } }
