/*
Rules: E13-10-4-goto-case-conversion-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/enum-no-implicit-conversion-c9acf48f50.cs.part
Mutate: goto case 1;
Into: goto case Choice.One;
*/
class Program
{
    enum Choice { Zero, One }
    static void Main()
    {
        Choice value = Choice.Zero;
        switch (value) { case Choice.Zero: goto case 1; case Choice.One: break; }
    }
}
