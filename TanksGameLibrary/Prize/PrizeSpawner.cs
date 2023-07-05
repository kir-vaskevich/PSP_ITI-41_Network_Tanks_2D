using System;
using EngineClassLibrary;
using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс спавнера призов.
    /// </summary>
    public class PrizeSpawner : GameObject
    {
        /// <summary>
        /// Ссылка на игру.
        /// </summary>
        private Game game;
        
        /// <summary>
        /// Таймер.
        /// </summary>
        private float _timer;

        /// <summary>
        /// Задержка выпадения призов.
        /// </summary>
        private float _delay;

        /// <summary>
        /// Объект для генерации координат карты.
        /// </summary>
        private Random _random = new Random();

        /// <summary>
        /// Фабрика призов.
        /// </summary>
        private PrizeFactory _prizeFactory;

        private static Texture sprite = ContentPipe.LoadTexture("1.png");

        /// <summary>
        /// Конструктор для создания спавнера призов.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        /// <param name="delay"></param>
        public PrizeSpawner(Vector position, Vector scale, float delay) : base(position, scale, sprite)
        {
            game = Game.game;
            _prizeFactory = new PrizeFactory();
        }

        /// <summary>
        /// Метод для генерации призов.
        /// </summary>
        public override void Update()
        {
            _timer += Time.DeltaTime;

            if (_timer >= _delay)
            {
                _timer = 0;
                _delay = 8;
                GameObject prize = _prizeFactory.GetRandomPrize(new Vector(_random.Next(-600, 600), _random.Next(-320, 320)), new Vector(0.25f, 0.25f));
                game.AddToAddObjects(prize);
            }
        }
    }
}
