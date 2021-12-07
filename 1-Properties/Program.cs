namespace Properties
{
    using System;
    using System.Linq;

    /// <summary>
    /// The seeds of italian cards.
    /// </summary>
    public enum ItalianSeeds
    {
        DENARI,
        COPPE,
        SPADE,
        BASTONI,
    }

    /// <summary>
    /// The names of italian cards.
    /// </summary>
    public enum ItalianNames
    {
        ASSO,
        DUE,
        TRE,
        QUATTRO,
        CINQUE,
        SEI,
        SETTE,
        FANTE,
        CAVALLO,
        RE,
    }

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            var df = new DeckFactory()
            {
                Names = Enum.GetNames(typeof(ItalianNames)).ToList(),
                Seeds = Enum.GetNames(typeof(ItalianSeeds)).ToList()
            };
            
            Console.WriteLine("The italian deck has " +df.GetDeckSize() + " cards");

            foreach (var c in df.Deck)
            {
                Console.WriteLine(c);
            }
        }
    }
}
