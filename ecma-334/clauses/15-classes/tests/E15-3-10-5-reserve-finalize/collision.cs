/*
Rules: E15-3-10-5-reserve-finalize; E15-3-10-1-reserve-finalizer-signature; E15-3-10-1-reserved-signature-collision
Authority: ECMA-334 7th ed 15.3.10
Version: 7.3
Expected: reject
Mutate: public void Finalize()
Into: public void Finish()
*/
class Receipt
{
    ~Receipt() { }
    public void Finalize() { }
}
class Program { static void Main() { } }
