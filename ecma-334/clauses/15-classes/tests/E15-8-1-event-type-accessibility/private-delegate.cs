/*
Rules: E15-8-1-event-type-accessibility
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: public event Handler Signal;
Into: private event Handler Signal;
Csc: CS7025
*/
public class Source { private delegate void Handler(); public event Handler Signal; }
class Program { static void Main() { } }
