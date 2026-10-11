/*
Rules: E13-6-4-no-external-continue
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: continue;
Into: return;
*/
class Program { static void Main() { while (false) { void Local() { continue; } } } }
