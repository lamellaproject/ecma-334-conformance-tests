/*
Rules: E15-4-constant-type-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: reject
Mutate: private enum Phase { Ready = 19 }
Into: public enum Phase { Ready = 19 }
Csc: CS0052
*/
public class Limits
{
    private enum Phase { Ready = 19 }
    public const Phase Current = Phase.Ready;
}
class Program { static void Main() { } }
