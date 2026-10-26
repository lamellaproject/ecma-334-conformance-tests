/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: SeedEnvelope(out int amount)
Into: SeedEnvelope(out long amount)
*/
class SeedEnvelope
{
    public SeedEnvelope(ref int amount) {}
    public SeedEnvelope(out int amount) { amount = 29; }
}
class EnvelopeEntry { static void Main() {} }
