using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StudentSimulator.UI
{
    interface IObjectUi
    {
        Vector2 Coordinates { get; set; }
        Texture2D Texture { get; }
        bool IsInteractable { get; }

        void LoadTexture(ContentManager content, string pathToTexture);
    }
}
