/*
Rules: E14-5-2-ed1-alias-member-name-unique
Authority: ECMA-334 1st ed 16.3.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E14-5-2-ed1-alias-member-name-unique/reopened-namespace-alias-class.witness.cs.part
Mutate: using Label =
Into: using NumericLabel =
*/
// ECMA-334 1st ed 16.3.1, p. 205 (PDF p. 219), lines 36-48. The 1st edition's 10.3
// combines namespace bodies; the 1st edition's 16.3.1 still requires uniqueness.
namespace Ledger { class Label { } }
namespace Ledger
{
    using Label = System.Int32;
    class Entry { public static int Main() { return 0; } }
}
