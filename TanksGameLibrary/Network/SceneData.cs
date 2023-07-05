using EngineClassLibrary;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TanksGameLibrary.Network
{
    public class SceneData
    {
        // Tank position
        public Vector Position { get; set; }

        public Vector Direction { get; set; }

        // Tank props
        public int Health { get; set; }

        public float Fuel { get; set; }

        public int Bullets { get; set; }

        // Game objects
        public List<Bullet> bullets { get; set; } = new List<Bullet>();

        public List<GameObject> prizes { get; set; } = new List<GameObject>();
        
        public void AddPrize(GameObject obj)
        {
            prizes.Add(obj);
        }

        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public SceneData()
        {
        }
    }
}
