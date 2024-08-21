using System.Collections.Generic;
using UnityEngine;

namespace PlayerClassInterfaces
{
    /// <summary>
    /// Class that represents the game world
    /// </summary>
    public class GameWorldInterfaces : MonoBehaviour
    {
        // Current interface reference
        private IAttack _currentIAttackEntity;
        private ILife _currentILifeEntity;

        // Current class reference
        private PlayerInterfaceExample _currentPlayer;
        private EnemyInterfaceExample _currentEnemy;
        private BeastInterfaceExample _currentBeast;

        // List of objects in the game world
        private List<PlayerInterfaceExample> _players;
        private List<EnemyInterfaceExample> _enemies;
        private List<NPCInterfaceExample> _npcs;
        private List<BeastInterfaceExample> _beasts;
        private List<BeastNoAttackInterfaceExample> _beastsNoAttack;

        // List of objects that have ILife interface implemented
        private List<ILife> _lifeEntities;

        // List of objects that have IAttack interface implemented
        private List<IAttack> _attackEntities;

        private void Start()
        {
            _players = new List<PlayerInterfaceExample>();
            _enemies = new List<EnemyInterfaceExample>();
            _npcs = new List<NPCInterfaceExample>();
            _beasts = new List<BeastInterfaceExample>();
            _beastsNoAttack = new List<BeastNoAttackInterfaceExample>();

            // Creates 50 units of each one
            for (int i = 0; i < 50; i++)
            {
                _players.Add(new PlayerInterfaceExample($"Player {i}", "Warrior", i, 100));
                _enemies.Add(new EnemyInterfaceExample($"Enemy {i}", "Orc", i, 100));
                _npcs.Add(new NPCInterfaceExample($"NPC {i}", "Villager", i, 100));
                _beasts.Add(new BeastInterfaceExample($"Beast {i}", "Wolf", i, 100));
                _beastsNoAttack.Add(new BeastNoAttackInterfaceExample($"Beast No Attack {i}", "Wolf", i, 100));
            }

            // Add all entities that uses the ILife interface to the _lifeEntities list
            _lifeEntities = new List<ILife>();
            _lifeEntities.AddRange(_players);
            _lifeEntities.AddRange(_enemies);
            _lifeEntities.AddRange(_npcs);
            _lifeEntities.AddRange(_beasts);
            _lifeEntities.AddRange(_beastsNoAttack);

            // Add all entities that uses the IAttack interface to the _attackEntities list. Notice how we can't add the
            // BeastNoAttackInterfaceExample class because it doesn't implement the IAttack interface
            _attackEntities = new List<IAttack>();
            _attackEntities.AddRange(_players);
            _attackEntities.AddRange(_enemies);
            _attackEntities.AddRange(_npcs);
            _attackEntities.AddRange(_beasts);
            // This will not work
            //_attackEntities.AddRange(_beastsNoAttack);

            /*
             * Through the use of interfaces, we can now create a list of entities that have the same behavior but
             * implemented in different ways.
             */

            // All units of a type attack, just like we did without interfaces
            foreach (var player in _players)
            {
                player.Attack();
            }

            foreach (var beast in _beasts)
            {
                beast.Attack();
            }

             // Can I attack with Just one unit referencing the base class? Yes, I can
             _currentPlayer = _players[Random.Range(0, _players.Count)];
             _currentEnemy = _enemies[Random.Range(0, _enemies.Count)];
             _currentBeast = _beasts[Random.Range(0, _beasts.Count)];

             _currentPlayer.Attack();
             _currentEnemy.Attack();
             _currentBeast.Attack();

             // Can I do the same but using interfaces? Yes, I can
             _currentIAttackEntity = _players[Random.Range(0, _attackEntities.Count)];
             _currentIAttackEntity.Attack();
             _currentIAttackEntity = _enemies[Random.Range(0, _attackEntities.Count)];
             _currentIAttackEntity.Attack();
             _currentIAttackEntity = _beasts[Random.Range(0, _attackEntities.Count)];
             _currentIAttackEntity.Attack();

             /*
              * Notice how we are using the IAttack interface to call the Attack method instead of a direct reference
              * to the class. This way, we can call the Attack method from any class that implements the IAttack
              * interface instead of having to call the Attack method from a direct reference to the class.
              */

             // Can all my entities attack? No, they can't. Remember that BeastNoAttackInterfaceExample doesn't
             // implement the IAttack interface, thus it doesn't have the Attack method.

             // Ths will not work
             //_currentIAttackEntity = _beastsNoAttack[Random.Range(0, _beastsNoAttack.Count)];
             //_currentIAttackEntity.Attack();
             
             // Can all my objects increase life at the same time? Yes, they can. Since we already have stored all
             // entities that have the ILife interface implemented
             foreach (var lifeEntity in _lifeEntities)
             {
                 lifeEntity.IncreaseLife(10);
             }

        }
    }
}