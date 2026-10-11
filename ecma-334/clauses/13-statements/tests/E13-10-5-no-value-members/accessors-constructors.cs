/*
Rules: E13-10-5-no-value-members
Authority: ECMA-334 7th ed 13.10.5
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: visits += 100; return;
Into: visits += 100; return 1;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    delegate void Handler();
    class Member
    {
        public static int visits;
        static Member() { visits += 1; return; }
        public Member() { visits += 10; return; }
        public int Property { set { visits += 100; return; } }
        public int this[int index] { set { visits += 1000; return; } }
        public event Handler Signal
        {
            add { visits += 10000; return; }
            remove { visits += 100000; return; }
        }
        // Finalizer invocation is not forced; acceptance of its bare return observes the return classification.
        ~Member() { return; }
    }
    static void Main()
    {
        Member member = new Member();
        Check(Member.visits == 11, "constructors-bare-returns");
        member.Property = 7;
        Check(Member.visits == 111, "property-set-bare-return");
        member[2] = 9;
        Check(Member.visits == 1111, "indexer-set-bare-return");
        Handler handler = delegate { };
        member.Signal += handler;
        Check(Member.visits == 11111, "event-add-bare-return");
        member.Signal -= handler;
        Check(Member.visits == 111111, "event-remove-bare-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
