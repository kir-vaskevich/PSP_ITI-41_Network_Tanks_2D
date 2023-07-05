using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using EngineClassLibrary;
using OpenTK;
using TanksGameLibrary.Network;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс игры.
    /// </summary>
    public class Game
    {
        private Client _client;
        /// <summary>
        /// Список объектов игры.
        /// </summary>
        private List<GameObject> _gameObjects;
        /// <summary>
        /// Список объектов для добавления в игру.
        /// </summary>
        private List<GameObject> _addGameObjects;
        /// <summary>
        /// Список индексов объектов игры, которые нужно удалить.
        /// </summary>
        private List<GameObject> _removeGameObjects;
        /// <summary>
        /// Статическая ссылка на игру.
        /// </summary>
        internal static Game game;
        /// <summary>
        /// Поле, которое обозначает конец игры.
        /// </summary>
        public bool End { get; protected set; }

        public bool player;
        // to transfer

        List<GameObject> addPrizes = new List<GameObject>();

        List<Bullet> addBullets = new List<Bullet>();

        public Tank tank;

        public Tank tank2;

        bool isMapInit = false;

        /// <summary>
        /// Конструктор, создающий экземпляр игры.
        /// </summary>
        public Game(Client client, bool player)
        {
            this.player = player;
            _client = client;
            if (game == null)
                game = this;
            _gameObjects = new List<GameObject>();
            _addGameObjects = new List<GameObject>();
            _removeGameObjects = new List<GameObject>();
            End = false;
        }

        /// <summary>
        /// Индексатор списка объектов игры.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GameObject this[int index]
        {
            get { return _gameObjects[index]; }
            private set { _gameObjects[index] = value; }
        }

        /// <summary>
        /// Свойство количества объектов в игре.
        /// </summary>
        public int Count { get => _gameObjects.Count; }

        public Map InitMap()
        {
            Map map = null;
            
            try
            {
                string json;
                do
                {
                    json = _client.GetData();
                } while (json == "");

                map = JsonSerializer.Deserialize<Map>(json);
                for (int i = 0; i < map.terrsList.Count; i++)
                {
                    GameObject obj = map.terrsList[i];
                    switch (obj.Tag)
                    {
                        case ObjType.NotDriveTerr:
                            map.terrsList[i] = new NotDriveTerritory(obj.Position, obj.Scale);
                            break;
                        case ObjType.NotDriveShootTerr:
                            map.terrsList[i] = new NotShootAndDriveTerritory(obj.Position, obj.Scale);
                            break;
                        case ObjType.NotShootTerr:
                            map.terrsList[i] = new NotShootTerritory(obj.Position, obj.Scale);
                            break;
                        case ObjType.SlowSpeedTerr:
                            map.terrsList[i] = new SlowSpeedTerritory(obj.Position, obj.Scale, 0.5f);
                            break;
                    }
                }
            }
            catch (Exception ex) { }
            
            // terrList from gameObj to territories
            return map;
        }

        public void InitTanks()
        {
            foreach (GameObject obj in _gameObjects)
            {
                if (obj is Tank && (obj as Tank).controlPlayer)
                    tank = obj as Tank;

                else if (obj is Tank && !(obj as Tank).controlPlayer)
                    tank2 = obj as Tank;
            }
        }

        public void WriteToSceneData(SceneData sceneData)
        {
            sceneData.Position = tank.Position;
            sceneData.Direction = tank.Direction;

            sceneData.Health = tank.Health;
            sceneData.Fuel = tank.Fuel;
            sceneData.Bullets = tank.Canon.Ammo;

            foreach (GameObject obj in addPrizes)
                sceneData.AddPrize(obj);

            addPrizes.Clear();

            foreach (Bullet obj in addBullets)
                sceneData.AddBullet(obj as Bullet);

            addBullets.Clear();
        }

        public void ReadTanksFromSceneData(SceneData sceneData)
        {
            tank2.Position = sceneData.Position;
            tank2.Direction = sceneData.Direction;

            tank2.Health = sceneData.Health;
            tank2.Fuel = sceneData.Fuel;
            tank2.Canon.Ammo = sceneData.Bullets;
        }

        public void ReadPrizesFromSceneData(SceneData sceneData)
        {
            foreach (GameObject obj in sceneData.prizes)
            {
                GameObject prize = null;
                switch (obj.Tag)
                {
                    case ObjType.BulletsPrize:
                        prize = new CanonBulletsPrize(obj.Position, obj.Scale, 15);
                        break;
                    case ObjType.SpeedPrize:
                        prize = new BoostSpeedPrize(obj.Position, obj.Scale, 1.25f);
                        break;
                    case ObjType.HealthPrize:
                        prize = new HealthPrize(obj.Position, obj.Scale, 30);
                        break;
                    case ObjType.FuelPrize:
                        prize = new FuelPrize(obj.Position, obj.Scale, 30);
                        break;
                    case ObjType.PowerPrize:
                        prize = new PowerPrize(obj.Position, obj.Scale, 2.0f);
                        break;
                }
                _gameObjects.Add(prize);
            }
        }

        public void ReadBulletsFromSceneData(SceneData sceneData)
        {
            foreach (Bullet obj in sceneData.bullets)
            {
                GameObject bullet = null;
                switch (obj.Tag)
                {
                    case ObjType.CanonBullet:
                        bullet = new CanonBullet(obj.Position, obj.Scale, obj.Direction, obj.Player, obj.Power);
                        break;
                    case ObjType.MachineGunBullet:
                        bullet = new MachineGunBullet(obj.Position, obj.Scale, obj.Direction, obj.Player, obj.Power);
                        break;
                }
                _gameObjects.Add(bullet);
            }
        }

        public void InitClient()
        {
            string jsonReceive;
            string jsonSend;

            // запись данных
            SceneData sceneData = new SceneData();
            WriteToSceneData(sceneData);

            // сериализация и отправка
            jsonSend = JsonSerializer.Serialize(sceneData);
            _client.SendData(jsonSend);

            // получение данных, десериализация и обратботка
            jsonReceive = _client.GetData();

            try
            {
                sceneData = JsonSerializer.Deserialize<SceneData>(jsonReceive);

                ReadTanksFromSceneData(sceneData);

                ReadPrizesFromSceneData(sceneData);

                ReadBulletsFromSceneData(sceneData);
            }
            catch (Exception ex)
            {
            }
            
        }

        /// <summary>
        /// Метод инициализации игры, происходит создание объектов.
        /// </summary>
        public void Init()
        {
            _gameObjects.Add(new Background(new Vector(800, 450), new Vector(1f, 1f)));

            Map map = InitMap();

            if (map != null)
                for (int i = 0; i < map.terrsList.Count; i++)
                    _gameObjects.Add(map.terrsList[i]);

            _gameObjects.Add(new Tank(new Vector(390, 30), new Vector(1f, 1f), Tank.spriteTank1_Left, false, player));
            _gameObjects.Add(new Tank(new Vector(-410, 30), new Vector(1f, 1f), Tank.spriteTank2_Right, true, !player));
            _gameObjects.Add(new PrizeSpawner(Vector.Zero, Vector.Zero, 3));

            // инициализация полей танков
            InitTanks();
            _client.SendData("ok");
            isMapInit = true;
        }

        #region Добавление/удаление объектов в список
        /// <summary>
        /// Добавление объектов в список для добавления.
        /// </summary>
        /// <param name="obj"></param>
        internal void AddToAddObjects(GameObject obj)
        {
            _addGameObjects.Add(obj);
            if (obj is Prize)
                addPrizes.Add(obj);
            else if (obj is Bullet)
                addBullets.Add(obj as Bullet);
        }

        /// <summary>
        /// Добавление объектов в список.
        /// </summary>
        public void AddToObjects()
        {
            _gameObjects.AddRange(_addGameObjects);
            _addGameObjects.Clear();
        }

        /// <summary>
        /// Удаляет из списка ненужные объекты.
        /// </summary>
        internal void RemoveObjects()
        {
            foreach (GameObject obj in _removeGameObjects)
            {
                _gameObjects.Remove(obj);
            }
            _removeGameObjects.Clear();
        }
        #endregion

        #region Проверки
        /// <summary>
        /// Проверяет закончилась ли игра.
        /// </summary>
        private void EndGame()
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject is Tank && (gameObject as Tank).Health <= 0)
                {
                     GameEvents.EndGame(gameObject.Player);
                }
            }
        }

        /// <summary>
        /// Проверяет столкнулась ли пуля с танком, если столкнулась - пуля удаляется, а у танка снимается здоровье.
        /// </summary>
        /// <param name="bullet"></param>
        /// <param name="indexInGameObjectsList"></param>
        private void BulletCheck(Bullet bullet, int indexInGameObjectsList)
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is Tank && Collider.IsObjectsCollided(bullet, _gameObjects[i])/* && bullet.Player != _gameObjects[i].Player*/)
                {
                    bullet.IsHit = true;
                    (_gameObjects[i] as Tank).Health -= bullet.Damage;
                    break;
                }
            }
            if (bullet.IsHit)
                _removeGameObjects.Add(bullet);
        }

        /// <summary>
        /// Проверяет столкновение приза с танком, если они столкнулись, то к танку применяется декорация.
        /// </summary>
        /// <param name="prize"></param>
        /// <param name="indexInGameObjectsList"></param>
        private void PrizeCheck(Prize prize, int indexInGameObjectsList)
        {
            for (int j = 0; j < _gameObjects.Count; j++)
            {
                if (_gameObjects[j] is Tank && Collider.IsObjectsCollided(prize, _gameObjects[j]))
                {
                    Tank tank = _gameObjects[j] as Tank;
                    prize.IsUse = true;
                    _gameObjects[j] = prize.Decorate(tank);
                    InitTanks();
                    break;
                }
            }
            if (prize.IsUse)
                _removeGameObjects.Add(prize);
        }

        private void TanksCollidingCheck()
        {
            if (Collider.IsObjectsTouched(tank, tank2))
            {
                if (tank.Position.X >= tank2.Position.X)
                {
                    tank.StopTank(new Vector(0.1f, 0));
                    tank2.StopTank(new Vector(-0.1f, 0));
                }
                else if (tank.Position.X < tank2.Position.X)
                {
                    tank.StopTank(new Vector(-0.1f, 0));
                    tank2.StopTank(new Vector(0.1f, 0));
                }
                if (tank.Position.Y >= tank2.Position.Y)
                {
                    tank.StopTank(new Vector(0, 0.1f));
                    tank2.StopTank(new Vector(0, -0.1f));
                }
                else if (tank.Position.Y < tank2.Position.Y)
                {
                    tank.StopTank(new Vector(0, -0.1f));
                    tank2.StopTank(new Vector(0, 0.1f));
                }
            }
        }
        
        private void TerritoryCheck(ITerritory terr)
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                if (_gameObjects[i] is Tank && terr.IsCollided(_gameObjects[i]))
                {
                    _gameObjects[i] = terr.Decorate(_gameObjects[i] as Tank);
                    InitTanks();
                }
                else if (_gameObjects[i] is Bullet && terr.IsCollided(_gameObjects[i]))
                {
                    (_gameObjects[i] as Bullet).IsHit = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Метод для рендеринга всех объектов игры и управления ими.
        /// </summary>
        public void Rendering()
        {
            EndGame();
            AddToObjects();
            if (isMapInit)
                InitClient();
            RemoveObjects();
            Time.UpdateTime();

            for (int i = 0; i < _gameObjects.Count; i++)
            {
                // отрисовка
                 SpriteBatch.Draw(_gameObjects[i]);
                // обновление состояний
                _gameObjects[i].Update();
                // проверка пуль
                if (_gameObjects[i] is Bullet)
                    BulletCheck(_gameObjects[i] as Bullet, i);

                else if (_gameObjects[i] is Prize)
                    PrizeCheck(_gameObjects[i] as Prize, i);

                else if (_gameObjects[i] is ITerritory)
                    TerritoryCheck(_gameObjects[i] as ITerritory);
            }
            TanksCollidingCheck();
        }
    }
}
