/*
Rules: E7-1-ordinary-call-accessible-member; E7-1-method-accessibility-modifiers
Authority: ECMA-334 7th ed 7.1
Version: 7.3
Expected: reject
Mutate: private static void Read()
Into: public static void Read()
*/
class Container
{
    private static void Read() { }
}
class Program
{
    static void Main() { Container.Read(); }
}
