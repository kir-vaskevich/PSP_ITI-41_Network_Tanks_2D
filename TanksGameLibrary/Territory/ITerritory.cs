using EngineClassLibrary;

namespace TanksGameLibrary
{
    interface ITerritory
    {
        bool IsDrive { get; set; }

        bool IsCollided(GameObject obj);

        Tank Decorate(Tank tank);
    }
}
