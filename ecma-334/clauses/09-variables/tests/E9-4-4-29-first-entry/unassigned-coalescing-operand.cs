/*
Rules: E9-4-4-29-first-entry
Authority: ECMA-334 7th ed 9.4.4.29
Version: 7.3
Expected: reject
Mutate: string text;
Into: string text = null;
Csc: CS0165
*/
class Program { static void Main() { string text; string result = text ?? "fallback"; } }
