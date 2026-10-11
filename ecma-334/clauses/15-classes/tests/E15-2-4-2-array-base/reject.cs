/*
Rules: E15-2-4-2-array-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: abstract class Gauge : System.Array
Into: abstract class Gauge : object
*/
abstract class Gauge : System.Array { }
class Program { static void Main() { } }
