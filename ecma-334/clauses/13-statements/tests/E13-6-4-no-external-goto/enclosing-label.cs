/*
Rules: E13-6-4-no-external-goto
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: goto target;
Into: return;
*/
class Program { static void Main() { target: ; void Local() { goto target; } } }
