using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    internal class RigidBody
    {
        public GameObject owner;
        public CircleCollider collider;

        public Vector2 Velocity;

        public Vector2 Position { get { return owner.Position; } }

        public bool IsActive { get { return owner.IsActive; } }
        public RigidBody(GameObject owner)
        {
            this.owner = owner;
            CollisionMngr.AddItem(this);
        }

        public bool Collides(RigidBody other) //Method used to being able to identify the best method to use for the collision
        {
            return collider.Collides(other.collider);
        }

        public void Destroy()
        {
            owner = null;
            if (collider != null)
            {
                collider.RigidBody = null;
                collider = null;
            }

            CollisionMngr.RemoveItem(this);
        }

    }
}
