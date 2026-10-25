/*
Rules: E14-5-2-ed1-alias-member-name-unique
Authority: ECMA-334 1st ed 16.3.1
Version: ISO-1
Expected: reject
Version-Witness: tests/E14-5-2-ed1-alias-member-name-unique/global-alias-class.witness.cs.part
Mutate: using Record =
Into: using TextRecord =
*/
// ECMA-334 1st ed 16.3.1, p. 205 (PDF p. 219), lines 36-48 forbids this unused
// alias/member collision.
using Record = System.String;
class Record { }
class Entry { public static int Main() { return 0; } }
