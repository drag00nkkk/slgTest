using UnityEngine;

namespace Factory
{
    public class JojoBody:IPerson
    {
        public JojoBody()
        {
            Debug.Log("Jojo !");
        }
        
        public string GetName()
        {
            return "JoJo";
        }

        public void DoCustom()
        {
            Debug.Log("Yalei Yalei");
        }
    }
    
    public class StarPolajiang:IStand
    {
        public StarPolajiang()
        {
            Debug.Log("Show [Star Polajiang]");
        }

        public void Attack()
        {
            Debug.Log("OuLa OuLa OuLa");
        }
    }

    public class JojoFactory:IFactory
    {
        public IPerson SpawnPerson()
        {
            var jojo = new JojoBody();
            jojo.DoCustom();
            return jojo;
        }

        public IStand SpawnStand()
        {
            return new StarPolajiang();
        }
    }
}