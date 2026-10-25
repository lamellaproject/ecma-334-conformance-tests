/*
Rules: E6-4-5-3-ed1-hex-minimum-long-forbidden
Authority: ECMA-334 1st ed 9.4.4.2
Version: ISO-1
Expected: reject
Version-Witness: tests/E6-4-5-3-ed1-hex-minimum-long-forbidden/hex-minimum-long.witness.cs.part
Mutate: 0x8000000000000000
Into: 9223372036854775808
*/
// ECMA-334 1st ed 9.4.4.2, p. 58 (PDF p. 72), lines 30-33. A hexadecimal ulong operand
// cannot use the decimal-only negation exception for the long minimum.
class Entry { public static int Main() { const long value = -0x8000000000000000; return value == long.MinValue ? 0 : 1; } }
