using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayerColistion
{
    class Player
    {
        private Texture2D _playerTexture;
        private Rectangle _playerBounds;
        private Vector2 _playerSpeed;
        private Color _playerColor;
        private float gravity;
        public Player(Texture2D playerTexture, Rectangle playerBounds, Vector2 playerSpeed, Color playerColor)
        {
            _playerTexture = playerTexture;
            _playerBounds = playerBounds;
            _playerSpeed = playerSpeed;
            _playerColor = playerColor;
            gravity = 25f;
        }
        public Texture2D PlayerTexture
        {
            get { return _playerTexture; }
        }
        public Rectangle PlayerBounds
        {
            get { return _playerBounds; }
            set { _playerBounds = value; }
        }
        public Vector2 PlayerSpeed
        {
            get { return _playerSpeed; }
            set { _playerSpeed = value; }
        }
        public Color PlayerColor
        {
            get { return _playerColor; }
            set{_playerColor = value; }
        }
        public bool PlayHitbyBady(Rectangle goody, Rectangle bady)
        {
            if(bady.Contains(goody))
                return true;
            else return false;
        }
        public void Move(GraphicsDeviceManager graphic,KeyboardState state)
        {
            PlayerBounds.Offset(_playerSpeed);
            while (_playerBounds.Bottom < graphic.PreferredBackBufferHeight)
                _playerBounds.Y += (int)gravity;
            if (state.IsKeyDown(Keys.A))
            {
                if (PlayerBounds.X - _playerSpeed.X < 0)
                    _playerBounds.X = 0;
                else
                    _playerBounds.X -=(int) _playerSpeed.X;
            }
            if(state.IsKeyDown(Keys.D))
            {
                if (PlayerBounds.X + _playerSpeed.X > graphic.PreferredBackBufferWidth-100)
                    _playerBounds.X = graphic.PreferredBackBufferWidth-100;
                else
                    _playerBounds.X +=(int) _playerSpeed.X;
            }
            if(state.IsKeyDown(Keys.S))
            {

            }
            if(state.IsKeyDown(Keys.W))
            {                
                if (PlayerBounds.Bottom < graphic.PreferredBackBufferHeight)
                    _playerBounds.Y = graphic.PreferredBackBufferHeight - 100;
                _playerBounds.Y -= (int)_playerSpeed.Y;                                
            }
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(PlayerTexture, PlayerBounds, PlayerColor);
        }
    }
}
