using System;

namespace FightGame
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Lives { get; set; }
        public int Power { get; set; }
        public int Gems { get; set; } = 0;
        public Gender Gender { get; set; }

        public void Status()
        {
            Console.WriteLine($"\n\n{Name}");
            Console.WriteLine("=========================");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Vidas: {Lives}");
            Console.WriteLine($"Poder: {Power}");
            Console.WriteLine($"Gemas: {Gems}");

            // si se cumple la condicion se hace ? si no se cumple, entonces se hace :.
            var genderDisplay = (Gender == Gender.Male)
                ? "Hombre"
                : "Mujer";

            Console.WriteLine($"Género: {genderDisplay}");

            Console.WriteLine($"\n\n {Name}\t\t{Lives}\t{Power}\t{Gems}");

        }

        public void Train()
        {

        }
    }
}
