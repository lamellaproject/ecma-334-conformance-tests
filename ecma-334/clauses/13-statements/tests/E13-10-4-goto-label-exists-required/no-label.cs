/*
Rules: E13-10-4-goto-label-exists-required
Authority: ECMA-334 7th ed 13.10.4
Version: 7.3
Expected: reject
Mutate: goto missing;
Into: goto present;
*/
class Program { static void Main() { goto missing; present: ; } }
