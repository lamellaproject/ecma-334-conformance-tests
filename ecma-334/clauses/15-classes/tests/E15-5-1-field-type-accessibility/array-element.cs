/*
Rules: E15-5-1-field-type-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: private class Packet { }
Into: public class Packet { }
Csc: CS0052
*/
public class Holder
{
    private class Packet { }
    public Packet[] Values;
}
class Program { static void Main() { } }
