namespace TanksGameLibrary
{
    /// <summary>
    /// Класс деоратора скорости.
    /// </summary>
    public class SpeedDecorator : TankDecorator
    {
        /// <summary>
        /// Скорость.
        /// </summary>
        private float _speed;

        /// <summary>
        /// Конструктор для обертывания танка.
        /// </summary>
        /// <param name="tank"></param>
        /// <param name="speed"></param>
        public SpeedDecorator(Tank tank, float speed)
            : base(tank)
        {
            this._speed = speed;
            this.Speed = (int)(tank.Speed * _speed);
        }
    }
}
