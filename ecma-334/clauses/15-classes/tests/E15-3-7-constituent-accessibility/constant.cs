/*
Rules: E15-3-7-constituent-accessibility
Authority: ECMA-334 7th ed 15.3.7
Version: 7.3
Expected: reject
Mutate: private enum Code
Into: public enum Code
*/
public class Packet
{
    private enum Code { Ready }
    public const Code Initial = Code.Ready;
}
class Program { static void Main() { } }
