namespace TanksGameLibrary
{
    /// <summary>
    /// Класс событий игры.
    /// </summary>
    public class GameEvents
    {
        /// <summary>
        /// Делегат, представляющий событие EndGame.
        /// </summary>
        /// <param name="winner"></param>
        public delegate void EndGameDelegate(bool winner);

        /// <summary>
        /// Свойство событий игры.
        /// </summary>
        public static EndGameDelegate EndGame { get; set; }

    }
}
