using UnityEngine;

namespace Factory
{
    public class DioBody:IPerson
    {
        public DioBody()
        {
            Debug.Log("Dio !");
        }

        public string GetName()
        {
            return "Jojo";
        }

        public void MakeAmazingPost()
        {
            Debug.Log("JoJo stand");
        }
    }
    
    public class ZaWaLuDuo:IStand
    {
        public ZaWaLuDuo()
        {
            Debug.Log("Show [Star ZaWaLuDuo]");
        }
        
        public void Attack()
        {
            Debug.Log("MuDa MuDa MuDa");
        }

        public void SetPosition(float distance)
        {
            if (distance > 10)
            {
                distance = 10;
            }
            Debug.Log($"Set ZaWaLuDuo position {distance}");
        }
    }
    
    public class DioFactory : IFactory
    {
        public IPerson SpawnPerson()
        {
            var dio = new DioBody();
            dio.MakeAmazingPost();
            return dio;
        }

        public IStand SpawnStand()
        {
            var stand = new ZaWaLuDuo();
            stand.SetPosition(20);
            return stand;
        }
    }
}