/*
Rules: E13-6-4-no-external-break
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: reject
Mutate: break;
Into: return;
*/
class Program { static void Main() { while (false) { void Local() { break; } } } }
