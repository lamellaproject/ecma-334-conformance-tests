/*
Rules: E15-2-2-1-duplicate-modifier
Authority: ECMA-334 7th ed 15.2.2.1
Version: 7.3
Expected: reject
Mutate: public public class Gauge
Into: public class Gauge
*/
public public class Gauge { }
class Program { static void Main() { } }
