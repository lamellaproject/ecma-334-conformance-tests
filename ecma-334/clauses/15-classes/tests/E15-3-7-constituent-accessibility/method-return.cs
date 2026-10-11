/*
Rules: E15-3-7-constituent-accessibility
Authority: ECMA-334 7th ed 15.3.7
Version: 7.3
Expected: reject
Mutate: private class Token
Into: public class Token
*/
public class Packet
{
    private class Token { }
    public Token Read() { return null; }
}
class Program { static void Main() { } }
