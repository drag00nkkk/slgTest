using UnityEngine;

namespace Factory
{
    interface IFactory
    {
        IPerson SpawnPerson();
        IStand SpawnStand();
    }

    public interface IPerson
    {
        string GetName();
    }

    public interface IStand
    {
        void Attack();
    }
}