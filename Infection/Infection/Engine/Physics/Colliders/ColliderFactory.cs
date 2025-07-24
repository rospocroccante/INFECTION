using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    static class ColliderFactory
    {
        public static CircleCollider CreateCircleFor(GameObject owner, bool innerCircle = true)
        {
            float radius;

            if (innerCircle)
            {
                if (owner.HalfWidth < owner.HalfHeight)
                {
                    radius = owner.HalfWidth;
                }
                else
                {
                    radius = owner.HalfHeight;
                }
            }
            else
            {
                radius = (float)Math.Sqrt(owner.HalfWidth * owner.HalfWidth + owner.HalfHeight * owner.HalfHeight);
            }

            return new CircleCollider(owner.body, radius);
        }
    }
}
