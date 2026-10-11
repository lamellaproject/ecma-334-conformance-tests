/*
Rules: E13-10-5-anonymous-return-affects-conversions
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: reject
Mutate: delegate { return 3.5; }
Into: delegate { return (int)3.5; }
*/

class Program
{
    delegate int Result();
    static Result factory = delegate { return 3.5; };
    static void Main() { }
}
