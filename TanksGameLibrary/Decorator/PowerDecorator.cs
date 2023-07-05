namespace TanksGameLibrary
{
    /// <summary>
    /// Класс декоратора мощности.
    /// </summary>
    public class PowerDecorator : TankDecorator
    {
        /// <summary>
        /// Коэффициент мощности.
        /// </summary>
        private float _power;

        /// <summary>
        /// Конструктор для создания декоратора.
        /// </summary>
        /// <param name="tank"></param>
        /// <param name="power"></param>
        public PowerDecorator(Tank tank, float power)
            : base(tank)
        {
            this._power = power;
            Canon.Power *= power;
            MachineGun.Power *= power;
        }

        /// <summary>
        /// Переопределенной свойство здоровья.
        /// </summary>
        public override int Health { get => base.Health; internal set => base.Health = value; }
    }
}
