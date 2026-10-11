/*
Rules: E15-3-9-3-class-nested-default-private
Authority: ECMA-334 7th ed 15.3.9.3
Version: 7.3
Expected: reject
Mutate: class Token { }
Into: public class Token { }
*/
class Packet { class Token { } }
class Program { static void Main() { Packet.Token token = null; } }
