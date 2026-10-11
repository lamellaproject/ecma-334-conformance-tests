/*
Rules: E7-5-5-event-type-accessibility
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: reject
Mutate: internal delegate void Hidden();
Into: public delegate void Hidden();
*/
internal delegate void Hidden();
public class Api { public event Hidden Signal; }
class Program { static void Main() { } }
