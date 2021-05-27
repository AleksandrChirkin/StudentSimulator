using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace StudentSimulator.UI
{
    interface IObjectUi
    {
        Vector2 Coordinates { get; set; }
        Texture2D Texture { get; }
        Texture2D FlashedTexture { get; }
        bool IsInteractable { get; }
        bool IsFlashed { get; set; }

        string Name { get; set; }

        void LoadTexture(ContentManager content, string pathToTexture);
        void LoadFlashedTexture(ContentManager content, string pathToTexture);
        bool MouseOnObj(float mouseX, float mouseY);
        bool MouseClickedOn(string state);
        void OnClick();
    }
}
