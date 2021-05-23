using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StudentSimulator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSimulator.UI
{
    interface IObjectUI
    {
        Vector2 Coordinates { get; set; }
        Texture2D Texture { get; }
        void LoadTexture(ContentManager content, string pathToTexture);

    }
}
