using OpenTK;
using EngineClassLibrary;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TanksGameLibrary
{
    /// <summary>
    /// Класс карты игры.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Двумерный массив территорий.
        /// </summary>
        public GameObject[,] terrs;
        
        public List<GameObject> terrsList { get; set; }

        /// <summary>
        /// Ширина экрана.
        /// </summary>
        private int width = 1600;

        /// <summary>
        /// Высота экрана.
        /// </summary>
        private int height = 900;

        /// <summary>
        /// Индексатор территорий.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public GameObject this[int i, int j]
        {
            get { return terrs[i, j]; }
        }

        /// <summary>
        /// Количесво строк карты.
        /// </summary>
        [JsonIgnore]
        public int Strings { get => terrs.GetLength(0); }

        /// <summary>
        /// Количестов столбцов карты.
        /// </summary>
        [JsonIgnore]
        public int Rows { get => terrs.GetLength(1); }

        /// <summary>
        /// Конструктор создающий карту.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="rows"></param>
        public Map(int strings, int rows)
        {
            var territoryFactory = new TerritoryFactory();
            terrs = new GameObject[strings, rows];
            terrsList = new List<GameObject>();
            Vector terrSize = new Vector(width / rows, height / strings);
            Vector terrPosition = new Vector(800, 450);
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    terrs[i, j] = territoryFactory.GetRandomTerritory(new Vector(terrPosition.X, terrPosition.Y), new Vector(0.625f, 0.625f));
                    if (terrs[i, j] != null && i != 4 && (j != 4 || j != 12))
                        terrsList.Add(terrs[i, j]);
                    terrPosition.X -= terrSize.X;
                }
                terrPosition.X = 800;
                terrPosition.Y -= terrSize.Y;
            }
            terrs[4, 4] = null;
            terrs[4, 12] = null;
        }

        public Map()
        {
            terrsList = new List<GameObject>();
        }
    }
}
