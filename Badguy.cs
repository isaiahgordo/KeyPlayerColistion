using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayerColistion
{
    class Badguy
    {
        private Texture2D _badText;
        private Rectangle _badBounds;
        private Vector2 _badSpeed;
        private Color _badColor;
        public Badguy(Texture2D badText, Rectangle badBounds, Vector2 badSpeed, Color badColor)
        {
            _badText = badText;
            _badBounds = badBounds;
            _badSpeed = badSpeed;
            _badColor = badColor;
        }
        public Texture2D BadText
        {
            get { return _badText; }
        }
        public Rectangle BadBounds
        {
            get { return _badBounds; }
            set { _badBounds = value; }
        }
        public Vector2 BadSpeed
        {
            get { return _badSpeed; }
            set { _badSpeed = value; }
        }
        public Color BadColor
        {
            get { return _badColor; }
            set
            {
                _badColor = value;
            }
        }
        public void Move(GraphicsDeviceManager graph)
        {
            BadBounds.Offset(_badSpeed);
            if (BadBounds.Left < 0 || BadBounds.Right > graph.PreferredBackBufferWidth)
                _badSpeed.X *= -1;
            _badBounds.X += (int)_badSpeed.X;
        }
        public bool BadTopHit(Rectangle bady, Rectangle goody)
        {
            if (goody.Bottom == bady.Top)
                return true;
            else
                return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BadText,BadBounds,BadColor);
        }
    }
}
