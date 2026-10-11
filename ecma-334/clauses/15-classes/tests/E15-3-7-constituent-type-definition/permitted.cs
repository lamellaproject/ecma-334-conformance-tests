/*
Rules: E15-3-7-constituent-type-definition
Authority: ECMA-334 7th ed 15.3.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Token
Into: private class Token
*/
using System;
public class Packet
{
    public class Token { public int Value; }
    public Token Field;
    public Token Echo(Token value) { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet packet = new Packet();
        Packet.Token token = new Packet.Token();
        token.Value = 71;
        packet.Field = token;
        Check(packet.Field.Value == 71, "accessible-field-constituent");
        Check(packet.Echo(token) == token, "accessible-method-return-and-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
