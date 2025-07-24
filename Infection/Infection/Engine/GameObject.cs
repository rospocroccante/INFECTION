using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Infection
{
    internal class GameObject : I_Updatable, I_Drawable
    {
        protected Sprite sprite;
        protected Texture texture;
        protected float speed;
        protected int frameW;
        protected int frameH;
        protected int textOffsetX, textOffsetY;
        public bool IsActive;
        public RigidBody body { get; protected set; }

        public virtual Vector2 Position { get { return sprite.position; } protected set { sprite.position = value; } }
        public float X { get { return sprite.position.X; } protected set { sprite.position.X = value; } }
        public float Y { get { return sprite.position.Y; } protected set { sprite.position.Y = value; } }
        public float HalfWidth { get; protected set; }
        public float HalfHeight { get; protected set; }

        public Vector2 Forward
        {
            get
            {
                return new Vector2((float)Math.Cos(sprite.Rotation), (float)Math.Sin(sprite.Rotation));
            }
            set
            {
                sprite.Rotation = (float)Math.Atan2(value.Y, value.X);
            }
        }

        public GameObject(string textureName, int textOffsetX = 0, int textOffsetY = 0, float spriteWidth = 0, float spriteHeight = 0)
        {
            texture = GfxMngr.GetTexture(textureName);
            float spriteW = spriteWidth > 0 ? spriteWidth : texture.Width; //The first option is used only for characters and not a Cell
            float spriteH = spriteHeight > 0 ? spriteHeight : texture.Height; //The first option is used only for characters and not a Cell
            sprite = new Sprite(spriteW, spriteH);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
            frameW = texture.Width;
            frameH = texture.Height;

            this.textOffsetX = textOffsetX; //Used only by TextChar
            this.textOffsetY = textOffsetY; //Used only by TextChar

            speed = 200f; //Used only by Cell
            HalfWidth = (int)sprite.Width * 0.5f;
            HalfHeight = (int)sprite.Height * 0.5f;
        }

        public virtual void Draw()
        {
            if(IsActive)
            {
                sprite.DrawTexture(texture,textOffsetX,textOffsetY, (int)sprite.Width, (int)sprite.Height);
            }
        }

        public virtual void Update()
        {
            
        }

        public virtual void OnCollide(GameObject other)
        {
            
        }

        public virtual void Destroy()
        {
            sprite = null;
            texture = null;

            UpdateMngr.RemoveItem(this);
            DrawMngr.RemoveItem(this);

            if (body != null)
            {
                body.Destroy();
                body = null;
            }
        }
    }
}
