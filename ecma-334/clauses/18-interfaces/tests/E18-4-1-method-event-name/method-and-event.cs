/*
Rules: E18-4-1-method-event-name; E18-4-1-unique-event-name
Authority: ECMA-334 7th ed 18.4.1
Version: 7.3
Expected: reject
Mutate: void Notice();
Into: void Read();
Csc: CS0102
*/
delegate void Signal();
interface INotice { event Signal Notice; void Notice(); }
class Program { static void Main() { } }
