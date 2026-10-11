/*
Rules: E15-2-4-2-delegate-base
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: abstract class Gauge : System.Delegate
Into: abstract class Gauge : object
*/
abstract class Gauge : System.Delegate { }
class Program { static void Main() { } }
