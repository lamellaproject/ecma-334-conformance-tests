/*
Rules: E18-6-5-event-name-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public event Notice Other
Into: public event Notice Ready
Csc: CS0535
*/
delegate void Notice();
interface ISource { event Notice Ready; }
class Source : ISource { public event Notice Other { add { } remove { } } }
class Program { static void Main() { } }
