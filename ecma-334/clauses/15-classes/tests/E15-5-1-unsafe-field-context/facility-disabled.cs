/*
Rules: E15-5-1-unsafe-field-context
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public unsafe int Value;
Into: public int Value;
Csc: CS0227
*/
// The configured compiler mode disables the unsafe-code facility.
class Holder { public unsafe int Value; }
class Program { static void Main() { Holder value = new Holder(); value.Value = 967; } }
