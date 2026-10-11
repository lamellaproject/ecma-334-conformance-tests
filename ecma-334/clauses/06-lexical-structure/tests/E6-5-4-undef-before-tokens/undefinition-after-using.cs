/*
Rules: E6-5-4-undef-before-tokens
Authority: ECMA-334 7th ed 6.5.4
Version: 7.3
Expected: reject
Mutate: #undef TOO_LATE
Into: // undefinition removed
*/
using System;
#undef TOO_LATE
class Program { static void Main() { } }
