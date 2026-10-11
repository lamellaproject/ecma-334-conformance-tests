/*
Rules: E13-8-3-governing-type-required
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: reject
Mutate: switch (null)
Into: switch ((object)null)
*/
class Program { static void Main() { switch (null) { default: break; } } }
