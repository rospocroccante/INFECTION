using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    static class CollisionMngr
    {
        public static List<RigidBody> RigidBodies;

        static CollisionMngr()
        {
            RigidBodies = new List<RigidBody>();
        }

        public static void AddItem(RigidBody item)
        {
            RigidBodies.Add(item);
        }

        public static void RemoveItem(RigidBody item)
        {
            RigidBodies.Remove(item);
        }

        public static void CheckCollision() //Method used to check for the collision of every cell with eachother
        {
            for (int i = 0; i < RigidBodies.Count; i++)
            {
                for (int j = i + 1; j < RigidBodies.Count; j++)
                {
                    if (RigidBodies[i].Collides(RigidBodies[j]) && RigidBodies[j].Collides(RigidBodies[i]))
                    {
                        RigidBodies[j].owner.OnCollide(RigidBodies[i].owner);
                        RigidBodies[i].owner.OnCollide(RigidBodies[j].owner);
                    }

                }
            }
        }
    }
}
