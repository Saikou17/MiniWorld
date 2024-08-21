using System.Collections.Generic;
using UnityEngine;

namespace PlayerClassNoInterfaces
{
    /// <summary>
    /// Class that represents the game world
    /// </summary>
    public class GameWorld  : MonoBehaviour
    {
        private Player _currentPlayer;
        private Enemy _currentEnemy;
        private Beast _currentBeast;


        // List of entities in the game world
        private List<Player> _players;
        private List<Enemy> _enemies;
        private List<NPC> _npcs;
        private List<Beast> _beasts;

        private void Start()
        {
            _players = new List<Player>();
            _enemies = new List<Enemy>();
            _npcs = new List<NPC>();
            _beasts = new List<Beast>();

           // Creates 50 units of each one
           for (int i = 0; i < 50; i++)
           {
               _players.Add(new Player("Player " + i, "Warrior " + i, i, 100));
               _enemies.Add(new Enemy("Enemy " + i, "Orc " + i, i, 100));
               _npcs.Add(new NPC("NPC " + i, "Merchant " + i, i, 100));
               _beasts.Add(new Beast("Beast " + i, "Wolf " + i, i, 100));
           }

           /*
            * Notice how we instantiate each class separately, creating a world full ob objects of each type.
            * Everything is OK, until we need to start to make specializations for each class.
            *
            * Let's say that we need to create a new class called "WildBeast" that has a special ability called "Roar".
            * We can use inheritance to create a new class called "WildBeast" that inherits from "Beast" and add the new ability.
            * But, what if we need to create a new class called "WildEnemy" that has the same ability "Roar"?
            * We can't inherit from "Enemy" and "Beast" at the same time.
            *
            * Also, as we start to specialize classes, we can ran into the problem of having a lot of classes that are very similar,
            * classes that have a lot of duplicated code or classes that no longer uses their base code.
            *
            * In our case, every class has the same method "Attack", but each class has a different implementation. That's OK.
            * But what if I want a Beast that should not attack, or an Enemy that neither should attack? Why should I have a method that I will not use?
            *
            * To avoid this, we can use interfaces to create a contract that each class must implement.
            */

           
           // If I want to attack with all entities, I need to call the Attack method of each class/object separately
           // Notice how I need a direct reference to each class/object to call the Attack method
           foreach (var player in _players)
           {
               player.Attack();
           }

           for (int i = 0; i < _enemies.Count; i++)
           {
               _enemies[i].Attack();
           }

           // But what if I want to attack using a specific uni? Then I need a direct reference to that Unit
           _currentPlayer = _players[Random.Range(0, _players.Count)];
           _currentEnemy = _enemies[Random.Range(0, _enemies.Count)];
           _currentBeast = _beasts[Random.Range(0, _beasts.Count)];

           _currentPlayer.Attack();
           _currentEnemy.Attack();
           _currentBeast.Attack();

           /*
            * Notice how we are using the Element class/object directly, and we are not using interfaces.
            * Also, we always need a direct reference to the class/object to call the Attack method.
            * I can't call the Attack method from a Beast class using a Player class reference.
            */

           // This will not work
           //_currentPlayer = _beasts[Random.Range(0, _players.Count)];
           //_currentPlayer.Attack();

           /*
            * Above issue can be solved by using interfaces. We can create an interface called IAttack that has the
            * Attack method.
            * Refer to the PlayerClassInterfaces project to see how we can use interfaces to solve this issue.
            */
        }
    }
}