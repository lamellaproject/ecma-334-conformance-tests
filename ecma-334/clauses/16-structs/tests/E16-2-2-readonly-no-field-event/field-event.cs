/*
Rules: E16-2-2-readonly-no-field-event
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: reject
Mutate: public event Action Signal;
Into: public event Action Signal { add { } remove { } }
*/
using System;
readonly struct Entry { public event Action Signal; }
class Program { static void Main() { } }
