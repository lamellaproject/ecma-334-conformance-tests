/*
Rules: E15-4-constant-type-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: private class Packet { }
Into: public class Packet { }
Csc: CS0052
*/
public class Limits
{
    private class Packet { }
    public const Packet Empty = null;
}
class Program { static void Main() { } }
