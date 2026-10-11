/*
Rules: E8-7-dynamic-attribute-argument-forbidden
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: (dynamic)1
Into: (object)1
*/
using System;
class StampAttribute : Attribute { public StampAttribute(object value) { } }
[Stamp((dynamic)1)] class Receiver { }
class Program { static void Main() { } }
