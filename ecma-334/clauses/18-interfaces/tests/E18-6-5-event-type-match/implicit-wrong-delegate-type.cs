/*
Rules: E18-6-5-event-type-match
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public event OtherNotice Ready
Into: public event Notice Ready
Csc: CS0738
*/
delegate void Notice();
delegate void OtherNotice();
interface ISource { event Notice Ready; }
class Source : ISource { public event OtherNotice Ready { add { } remove { } } }
class Program { static void Main() { } }
