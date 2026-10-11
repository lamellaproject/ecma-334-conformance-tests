/*
Rules: E6-5-4-define-before-tokens
Authority: ECMA-334 7th ed 6.5.4
Version: 7.3
Expected: reject
Mutate: #define TOO_LATE
Into: // definition removed
*/
using System;
#define TOO_LATE
class Program { static void Main() { } }
