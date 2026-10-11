/*
Rules: E16-2-3-no-instance-delegate
Authority: ECMA-334 7th ed 16.2.3
Version: 7.3
Expected: reject
Mutate: item.Read
Into: Entry.ReadStatic
*/
delegate int Getter();
ref struct Entry { public int Read() { return 3; } public static int ReadStatic() { return 3; } }
class Program { static void Main() { Entry item = default(Entry); Getter read = item.Read; } }
