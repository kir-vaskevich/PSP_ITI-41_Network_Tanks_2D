namespace TanksGameLibrary
{
    /// <summary>
    /// Класс базового декоратора.
    /// </summary>
    public class TankDecorator : Tank
    {
        /// <summary>
        /// Ссылка на танк.
        /// </summary>
        protected Tank tank;

        /// <summary>
        /// Конструктор для обертывания танка.
        /// </summary>
        /// <param name="tank"></param>
        public TankDecorator(Tank tank)
            : base(tank.Position, tank.Scale, tank.Texture, tank.Player, tank.controlPlayer)
        {
            this.tank = tank;
        }

        /// <summary>
        /// Метод возвращающий танк без декораций.
        /// </summary>
        /// <returns></returns>
        public Tank GetBase()
        {
            return tank;
        }
    }
}
