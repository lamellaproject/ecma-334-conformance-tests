/*
Rules: E15-2-5-constructor-argument-eligibility
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: public Record(int value)
Into: public Record()
*/
class Record { public Record(int value) { } }
class Box<T> where T : new() { }
class Program { static void Main() { Box<Record> item = null; } }
