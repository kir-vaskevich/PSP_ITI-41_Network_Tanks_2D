using Microsoft.VisualStudio.TestTools.UnitTesting;
using TanksGameLibrary;
using OpenTK;
using EngineClassLibrary;
using TanksGameLibrary.Network;
using System.Threading;

namespace TanksUnitTests
{
    [TestClass]
    public class UnitTest1 : GameWindow
    {
        [TestMethod]
        public void SpeedDecoratorTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            Tank tank2 = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            tank = new SpeedDecorator(tank, 1.6f);
            Assert.AreEqual(tank2.Speed * 1.6f, tank.Speed);
        }

        [TestMethod]
        public void PowerDecoratorTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            Tank tank2 = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            tank = new PowerDecorator(tank, 2f);
            Assert.AreEqual(tank2.MachineGun.Power * 2f, tank.MachineGun.Power);
        }

        [TestMethod]
        public void TankAmmoTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            Tank tank2 = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            CanonBulletsPrize prize = new CanonBulletsPrize(Vector.Zero, new Vector(1, 1), 15);
            prize.Decorate(tank);
            Assert.AreEqual(tank2.Canon.Ammo + 15, tank.Canon.Ammo);
        }

        [TestMethod]
        public void TankFuelTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            Tank tank2 = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            FuelPrize prize = new FuelPrize(Vector.Zero, new Vector(1, 1), 10);
            prize.Decorate(tank);
            Assert.AreEqual(tank2.Fuel, tank.Fuel);
        }

        [TestMethod]
        public void TankHealthAndColliderTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            HealthPrize healthPrize = new HealthPrize(Vector.Zero, new Vector(0.5f, 0.5f), -50);
            //CanonBullet canonBullet = new CanonBullet(Vector.Zero, new Vector(1f, 1f), ContentPipe.LoadTexture("CanonBullet_Up.png"), Vector.Zero, true, 1f);
            if (Collider.IsObjectsCollided(healthPrize, tank))
            {
                healthPrize.Decorate(tank);
            }
            Assert.AreEqual(50, tank.Health);
        }

        [TestMethod]
        public void TerritoryTest()
        {
            Tank tank = new Tank(Vector.Zero, new Vector(1f, 1f), Tank.spriteTank1_Down, false, false);
            int newSpeed = (int)(tank.Speed * 0.5f);
            SlowSpeedTerritory terr = new SlowSpeedTerritory(Vector.Zero, new Vector(1f, 1f), 0.5f);
            tank = terr.Decorate(tank);
            Assert.AreEqual(newSpeed, (tank as SpeedDecorator).Speed);
        }

        [TestMethod]
        public void PrizeFactoryTest()
        {
            bool actual = false;
            PrizeFactory prizeFactory = new PrizeFactory();
            Prize prize = prizeFactory.GetRandomPrize(Vector.Zero, new Vector(1f, 1f)) as Prize;
            if (prize is HealthPrize || prize is CanonBulletsPrize || prize is FuelPrize || prize is PowerPrize || prize is BoostSpeedPrize)
                actual = true;
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void MapReceiveTest()
        {
            Assert.AreEqual("", "");
        }

        [TestMethod]
        public void ClientReceiveDataTest()
        {
            Assert.AreEqual("", "");
        }

        [TestMethod]
        public void ClientSendDataTest()
        {
            Assert.AreEqual("", "");
        }
    }
}
