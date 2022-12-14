using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPlayerColistion
{
    class Coin
    {
        private Texture2D _coinTexture, _coinIcon;
        private Rectangle _coinTopRect,_coinRect;
        private Color _coinColor;
        private Vector2 _coinfont;
        private int _coinNum;
        public Coin(Texture2D coinText, Texture2D coinIcon, Rectangle coinTopRect, Rectangle coinRect, Color coinColor,Vector2 coinFont)
        {
            _coinTexture = coinText;
            _coinIcon = coinIcon;
            _coinTopRect = coinTopRect;
            _coinRect = coinRect;
            _coinColor = coinColor;
            _coinfont = coinFont;
            _coinNum = 0;
        }
        public Texture2D CoinText
        { get { return _coinTexture; } }
        public Texture2D CoinIcon
        { get { return _coinIcon; } }
        public Rectangle CoinTopRect
        {
            get { return _coinTopRect; }
            set { _coinTopRect = value; }
        }
        public Rectangle CoinRect
        { 
            get { return _coinRect; }
            set { _coinRect = value; }
        }
        public Color CoinColor
        {
            get { return _coinColor; }
            set { _coinColor = value; }
        }
        public int CoinNum
        { get { return _coinNum; } }
        public void Draw(SpriteBatch spriteBatch,SpriteFont font)
        {
            spriteBatch.Draw(CoinText,CoinRect,CoinColor);
            spriteBatch.Draw(CoinIcon,CoinTopRect,CoinColor);
            spriteBatch.DrawString(font, CoinNum.ToString(), _coinfont, CoinColor);
        }
    }
}
