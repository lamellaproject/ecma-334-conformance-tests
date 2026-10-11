/*
Rules: E15-10-1-operator-type-accessibility
Authority: ECMA-334 7th ed 15.10.1
Version: 7.3
Expected: reject
Mutate: internal class Token
Into: public class Token
Csc: CS0056
*/
internal class Token { }
public class Gauge { public static Token operator +(Gauge x) { return new Token(); } }
class Program { static void Main() { } }
