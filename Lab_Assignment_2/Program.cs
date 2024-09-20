namespace Lab_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePlayer manager = new GamePlayer();
            manager.Play();
            manager.Print();
            //Creates a instance for Gameplayer and constructs it.
        }
    }

    /* + is an operation that adds two numbers.
     * score = oldscore + newscore
     * - is an operation that subtracts two numbers.
     * score = oldscore - newscore
     * * is an operation that multiplies two numbers.
     * score = oldscore * newscore
     * ++ is an operation that can be used for adding two numbers and assigning the value to the same string.
     * oldscore ++ newscore
     * -- is an operation that can be used for subtracts two numbers and assigning the value to the same string.
     * oldscore -- newscore
     * / is an operation that divides two numbers.
     * score = oldscore / newscore
     * % is an operation that returns the reminder of two values.
     */
}
