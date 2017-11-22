
using System;
using System.Collections.Generic;

namespace FightGame
{
    public class Game
    {
        public const int DefaultLives = 1;
        public const int DefaultPower = 10;

        public List<Player> Players { get; set; }

        private Random _random = new Random();

        public Game()
        {
            Players = new List<Player>();

            new Player
            {
                Name = "Javi",
                Gender = Gender.Male,
                Lives = DefaultLives,
                Power = DefaultPower
            };

            new Player
            {
                Name = "Coralina",
                Gender = Gender.Female,
                Lives = DefaultLives,
                Power = DefaultPower
            };
        }

        // cambio chorra
        // tonta
        // otra caca

        public void Start()
        {
            Console.Write(@"___________.__       .__     __      ________                       
\_   _____/|__| ____ |  |___/  |_   /  _____/_____    _____   ____  
 |    __)  |  |/ ___\|  |  \   __\ /   \  ___\__  \  /     \_/ __ \ 
 |     \   |  / /_/  >   Y  \  |   \    \_\  \/ __ \|  Y Y  \  ___/ 
 \___  /   |__\___  /|___|  /__|    \______  (____  /__|_|  /\___  >
     \/      /_____/      \/               \/     \/      \/     \/ ");
            Menu();
        }

        private void Menu()
        {
            Console.WriteLine("\n\nElige una opción:");
            Console.WriteLine("---   ┐(°_°)┌   ---");
            Console.WriteLine("\n1. Añadir Jugador");
            Console.WriteLine("2. Estatus");
            Console.WriteLine("3. Luchar");
            Console.WriteLine("4. Rango");
            Console.WriteLine("5. Salir");

            ConsoleKeyInfo option = Console.ReadKey();

            switch (option.KeyChar)
            {
                case '1':
                    AddPlayer();
                    break;

                case '2':
                    Status();
                    break;

                case '3':
                    Fight();
                    break;

                case '4':
                    Ranking();
                    break;

                case '5':
                    Console.WriteLine("\n\n¿Estás seguro? (s/n)");
                    var answer = Console.ReadKey();
                    if (answer.KeyChar != 's')
                    {
                        Menu();
                    }
                    break;

                default:
                    Console.WriteLine("\n ┐(°_°')┌ Solo hay que escribir un número. ¿Es tan difícil?");
                    Menu();
                    break;
            }


        }

        public void AddPlayer()
        {
            string name = null;

            while (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                Console.WriteLine("Escribe el nomre del jugador (y presiona Enter):");
                name = Console.ReadLine();
            }

            Gender? gender = null;
            while (gender == null)
            {
                Console.WriteLine("Elige genero:\n1. Femenino\n2. Masculino");
                var genderKey = Console.ReadKey();

                if (genderKey.KeyChar == '1')
                {
                    gender = Gender.Female;
                }

                else if (genderKey.KeyChar == '2')
                {
                    gender = Gender.Male;
                }

                else
                {
                    Console.WriteLine("\nEl valor introducido es erróneo.\n");
                }
            }
            /* ES LO MISMO QUE LO DE ABAJO PERO MENOS EFICIENTE
            var player = new Player();
            player.Gender = gender.Value;
            player.Name = name;
            */
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Gender = gender.Value,
                Name = name,
                Power = DefaultPower,
                Lives = DefaultLives,
            };

            Players.Add(player);

            Console.WriteLine("\n\n Jugador añadido");
            player.Status();
            Console.ReadKey();
            Menu();
        }

        public void Fight()
        {
            if (Players.Count == 0)
            {
                Console.WriteLine("\n ┐(°_°')┌ no hay suficientes jugadores");
            }

            else
            {
                /* "Es lo mismo que lo de abajo pero mas cómplicado."
                var playersCopy = new List<Player>(Players.ToArray());
                var indexPlayer1 = _random.Next(0, Players.Count);
                var player1 = playersCopy[indexPlayer1];

                playersCopy.RemoveAt(indexPlayer1);
                var indexPlayer2 = _random.Next(0, Players.Count);
                var player2 = playersCopy[indexPlayer2]; */

                //"var e int son similares en este caso"

                var indexPlayer1 = _random.Next(0, Players.Count);
                int indexPlayer2 = 0;

                while (indexPlayer1 == indexPlayer2)
                {
                    indexPlayer2 = _random.Next(0, Players.Count);
                }

                var player1 = Players[indexPlayer1];
                var player2 = Players[indexPlayer2];

                var damage = _random.Next(1, 5);

                player2.Power -= damage;
                Console.WriteLine($"{player1} ha dañado a {player2}");
                

                if (player2.Power <= 0)
                {
                    player2.Lives --;
                    player1.Gems ++;

                    if (player2.Lives > 0)
                        Console.WriteLine($"{player2.Name} a perdido una vida");
                    else
                        Console.WriteLine($"{player2.Name} a muerto");
                }

                Console.WriteLine("\n Pulsas Intro para luchar de nuevo" + "Cualquier otra tecla del menu");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                    Fight();
                
                else
                    Menu();
            }
        }

        public void Ranking()
        {

        }

        public void Status()
        {
            if (Players.Count == 0)
            {
                Console.WriteLine("\nNo hay jugadores");
            }
            else
            {
                foreach (var player in Players)
                {
                    player.Status();
                }
            }
            
            Console.ReadKey();
        }
    }
}
