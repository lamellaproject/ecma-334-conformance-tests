/*
Rules: E15-5-1-field-type-accessibility
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Mutate: private enum Phase { Idle }
Into: public enum Phase { Idle }
Csc: CS0052
*/
public class Holder
{
    private enum Phase { Idle }
    public Phase Value;
}
class Program { static void Main() { } }
