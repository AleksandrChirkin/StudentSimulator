using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace StudentSimulator.UI
{
    interface IObjectUi
    {
        Vector2 Coordinates { get; set; }
        Texture2D Texture { get; }
        Texture2D FlashedTexture { get; }
        bool IsInteractable { get; }
        bool IsFlashed { get; set; }
        bool IsStatic { get; }
        bool IsMooving { get; set; }

        string Name { get; set; }

        void LoadTexture(ContentManager content, string pathToTexture);
        void LoadFlashedTexture(ContentManager content, string pathToTexture);
        bool MouseOnObj(float mouseX, float mouseY);
        bool MouseClickedOn(string state);
        void OnClick(IObjectUi player);
        void MoveTo();
        void SetMoveDestination(float destinationX, int speed);
    }
}
