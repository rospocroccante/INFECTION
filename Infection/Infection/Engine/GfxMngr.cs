﻿using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    static class GfxMngr
    {
        private static Dictionary<string, Texture> textures;

        static GfxMngr()
        {
            textures = new Dictionary<string, Texture>();
        }

        public static Texture AddTexture(string name, string path)
        {
            Texture t = new Texture(path);

            if (t != null)
            {
                textures[name] = t;
            }

            return t;
        }

        public static Texture GetTexture(string name)
        {
            Texture t = null;

            if (textures.ContainsKey(name))
            {
                t = textures[name];
            }

            return t;
        }

        public static void ClearAll()
        {
            textures.Clear();
        }
    }
}


