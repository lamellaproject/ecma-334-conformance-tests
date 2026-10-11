/*
Rules: E15-11-1-constructor-parameter-type-accessibility
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: reject
Mutate: internal class Token
Into: public class Token
Csc: CS0051
*/
internal class Token { }
public class Gauge { public Gauge(Token x) { } }
class Program { static void Main() { } }
