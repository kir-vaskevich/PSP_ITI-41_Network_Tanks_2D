using EngineClassLibrary;
using OpenTK;
using System;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс фабрики территорий.
    /// </summary>
    public class TerritoryFactory
    {
        /// <summary>
        /// Объект для генерации рандомных чисел.
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Метод возвращающий рандомную территорию.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public GameObject GetRandomTerritory(Vector position, Vector scale)
        {
            GameObject territory = null;
            switch (random.Next(0, 15))
            {
                case 1:
                    territory = new NotShootTerritory(position, scale);
                    territory.Tag = ObjType.NotShootTerr;
                    break;
                case 3:
                    territory = new SlowSpeedTerritory(position, scale, 0.75f);
                    territory.Tag = ObjType.SlowSpeedTerr;
                    break;
                case 5:
                    territory = new NotDriveTerritory(position, scale);
                    territory.Tag = ObjType.NotDriveTerr;
                    break;
                case 6:
                    territory = new NotShootAndDriveTerritory(position, scale);
                    territory.Tag = ObjType.NotDriveShootTerr;
                    break;
            }
            return territory;
        }
    }
}
