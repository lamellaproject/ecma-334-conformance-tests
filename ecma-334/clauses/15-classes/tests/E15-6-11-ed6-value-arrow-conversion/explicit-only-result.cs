/*
Rules: E15-6-11-ed6-value-arrow-conversion
Authority: ECMA-334 6th ed 14.6.11
Version: 6
Expected: reject
Version-Witness: tests/E15-6-11-ed6-value-arrow-conversion/explicit-only-result.witness.cs.part
Mutate: public static explicit operator Ticket
Into: public static implicit operator Ticket
*/
class Ticket
{
    public readonly int Code;
    Ticket(int code) { Code = code; }
    public static explicit operator Ticket(int code) { return new Ticket(code); }
}
class Program
{
    static Ticket Issue(int code) => code;
    static int Main()
    {
        int checks = 0;
        int failures = 0;
        checks++;
        if (!(Issue(11).Code == 11))
        {
            failures++;
            System.Console.WriteLine("FAIL converted-ticket-code");
        }
        if (failures == 0) System.Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
