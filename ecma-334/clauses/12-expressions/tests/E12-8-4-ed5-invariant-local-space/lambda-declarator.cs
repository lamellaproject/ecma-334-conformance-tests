/*
Rules: E12-8-4-ed5-invariant-local-space
Authority: ECMA-334 5th ed 12.7.3.2
Version: 5
Expected: reject
Version-Witness: version-witnesses/E12-8-4-ed5-invariant-local-space/lambda-declarator.cs.part
Mutate: int Readout = 24;
Into: int Spare = 24;
*/
delegate int Sampler();
class Program
{
    static int Readout() { return 58; }
    static void Main()
    {
        Sampler sample = () =>
        {
            int saved = Readout();
            { int Readout = 24; }
            return saved;
        };
        int observed = sample();
    }
}
