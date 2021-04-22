using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.Domain
{
    public static class GameManipulator
    {
        /* Кажется, можно добавить поле Dictionary<int, Game> games, но я сам не уверен, что оно нужно.
         Нам же нужно либо дважды вызывать GetListOfGames, либо постоянно хранить games, что плохо для памяти*/
        public static Game currentGame { get; private set; }
        public static List<Game> GetListOfGames() => new List<Game>();
        /*Думаю, тут стоит возвращать словарь, где ключ - id игры, а значение - сама игра
        Это позволит быстрее находить нужную нам игру при загрузке и сохранении
        (сам метод можно переименовать в GetGames)*/
        
        public static void CreateGame() { }

        public static void LoadGame() { }
        /*На самом деле, единственное, что это метод должен делать - менять значение currentGame
        Объект класса Game уже был создан методом GetGames и использован в графике
        Кстати, стоит передавать в качестве аргумента Game, чтобы можно было сходу приравнять currentGame к нему*/
        
        public static void SaveGame() { }
        /*Вызывается при закрытии игры.
        Вызывает внутри себя метод GetGames, чтобы посмотреть, не была ли она сохранена ранее
        Если да, то данные о соответствующей игре перезаписываются; если нет - добавляются*/
    }
}
