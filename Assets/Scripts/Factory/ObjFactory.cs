using System.Collections.Generic;
using Objects.Pawn;
using Utils;

namespace Factory
{
    public class ObjFactory
    {
        private Dictionary<EPawnType, List<IPawn>> _pool = new Dictionary<EPawnType, List<IPawn>>();
        
        public IPawn SpawnPawn<T>(EPawnType pawnType) where T : IPawn, new()
        {
            IPawn newPawn;
            if (_pool.ContainsKey(pawnType) && _pool[pawnType].Count > 0)
            {
                newPawn = _pool[pawnType][_pool.Count - 1];
                _pool[pawnType].RemoveAt(_pool.Count - 1);
            }
            else
            {
                newPawn = new T();
            }
            newPawn.Reset();
            return newPawn;
        }

        public void DespawnPawn(IPawn inPawn)
        {
            var pawnType = inPawn.GetType();
            if (!_pool.ContainsKey(pawnType))
            {
                _pool.Add(pawnType, new List<IPawn>());
            }

            inPawn.WillDespawn();
            _pool[pawnType].Add(inPawn);
        }
    }
}