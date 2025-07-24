using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    abstract class Collider
    {
        public RigidBody RigidBody;
        public Vector2 Position { get { return RigidBody.Position; } }

        public Collider(RigidBody owner)
        {
            RigidBody = owner;
        }

        public abstract bool Collides(CircleCollider collider);
    }
}
