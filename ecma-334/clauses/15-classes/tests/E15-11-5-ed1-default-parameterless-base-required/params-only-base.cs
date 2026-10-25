/*
Rules: E15-11-5-ed1-default-parameterless-base-required
Authority: ECMA-334 1st ed 17.10.4
Version: ISO-1
Expected: reject
Version-Witness: tests/E15-11-5-ed1-default-parameterless-base-required/params-only-base-repair.cs.part
Mutate: class Branch : Root { }
Into: class Branch : Root { public Branch() : base() { } }
*/
// ECMA-334 1st ed 17.10.4, p. 264 (PDF p. 278), lines 53-55. Refuse an automatically
// supplied default constructor when its direct base class has no accessible zero-parameter
// instance constructor.

class Root
{
    public Root(params int[] entries) { }
}

class Branch : Root { }

class ProbeMain
{
    public static int Main()
    {
        return 0;
    }
}
