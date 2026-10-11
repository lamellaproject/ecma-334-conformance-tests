/*
Rules: E15-8-1-external-no-modify-handler-list; E15-8-1-external-event-only-add-remove
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Mutate: source.Signal = handler;
Into: source.Signal += handler;
Csc: CS0070
*/
class Source { public event System.Action Signal; }
class Program { static void Main() { Source source = new Source(); System.Action handler = () => { }; source.Signal = handler; } }
