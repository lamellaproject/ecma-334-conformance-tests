/*
Rules: E15-8-1-event-remove-result-void
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: System.Action result = (source.Signal -= handler);
Into: source.Signal -= handler;
Csc: CS0029
*/
class Source { public event System.Action Signal; }
class Program { static void Main() { Source source = new Source(); System.Action handler = () => { }; System.Action result = (source.Signal -= handler); } }
