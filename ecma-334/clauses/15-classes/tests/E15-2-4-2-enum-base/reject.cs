/*
Rules: E15-2-4-2-enum-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: abstract class Gauge : System.Enum
Into: abstract class Gauge : object
*/
abstract class Gauge : System.Enum { }
class Program { static void Main() { } }
