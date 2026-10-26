/*
Rules: E12-8-4-ed2-declarator-name-invariance
Authority: ECMA-334 2nd ed 14.5.2.1
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/ed2-switch-declarator-invariance.cs.part
Mutate: int Readout = 8;
Into: int Reading = 8;
*/
class NameLedger
{
    static int Readout() { return 67; }
    static void Main()
    {
        switch (1)
        {
            case 1:
                int total = Readout();
                { int Readout = 8; }
                System.Console.WriteLine(total);
                break;
        }
    }
}
