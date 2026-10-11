/*
Rules: E15-3-9-3-nonnested-default-internal
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: reject
Mutate: class Token { }
Into: public class Token { }
*/
class Token { }
public class Packet { public Token Field; }
class Program { static void Main() { } }
