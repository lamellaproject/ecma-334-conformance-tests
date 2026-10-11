/*
Rules: E15-2-5-constructor-argument-eligibility
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: private Record()
Into: public Record()
*/
class Record { private Record() { } }
class Box<T> where T : new() { }
class Program { static void Main() { Box<Record> item = null; } }
