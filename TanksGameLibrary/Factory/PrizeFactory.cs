using System;
using EngineClassLibrary;

using OpenTK;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс фабрики призов.
    /// </summary>
    public class PrizeFactory
    {
        /// <summary>
        /// Объект для выбора случайных призов.
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Метод, который возвращает рандомный приз.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public GameObject GetRandomPrize(Vector position, Vector scale)
        {
            GameObject prize;
            switch(random.Next(1, 6))
            {
                case 1:
                    prize = new CanonBulletsPrize(position, scale, 15);
                    prize.Tag = ObjType.BulletsPrize;
                    break;
                case 2:
                    prize = new BoostSpeedPrize(position, scale, 1.25f);
                    prize.Tag = ObjType.SpeedPrize;
                    break;
                case 3:
                    prize = new HealthPrize(position, scale, 30);
                    prize.Tag = ObjType.HealthPrize;
                    break;
                case 4:
                    prize = new FuelPrize(position, scale, 30);
                    prize.Tag = ObjType.FuelPrize;
                    break;
                case 5:
                    prize = new PowerPrize(position, scale, 2.0f);
                    prize.Tag = ObjType.PowerPrize;
                    break;
                default:
                    throw new Exception("Неверный диапазон рандома.");
            }
            return prize;
        }
    }
}
