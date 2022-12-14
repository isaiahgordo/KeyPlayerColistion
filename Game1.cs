using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KeyPlayerColistion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;        
        Badguy badguy;
        Coin coin;
        Texture2D playText,coinText,badGuyText,wallText;
        SpriteFont font;
        Rectangle mater;
        int gPH,gPW,lives;
        Screen screen;
        bool phit,bhit;
        Point callerl;
        enum Screen
        {
            Intro,Game,End
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            lives = 3;
            callerl = player.PlayerBounds.Location;
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            gPH = _graphics.PreferredBackBufferHeight-100;
            gPW = _graphics.PreferredBackBufferWidth-100;
            base.Initialize();
            player = new Player(playText, new Rectangle(0, gPH, 100, 100), new Vector2((float)12.5, 200), Color.White);            
            badguy = new Badguy(badGuyText, new Rectangle(190, gPH , 100, 100), new Vector2((float)6.25, 0), Color.White);
            coin = new Coin(coinText, coinText, new Rectangle(280, 280, 25, 25), new Rectangle(gPW+75, 0, 25, 25), Color.White,new Vector2(gPW-50,0));
            mater = player.PlayerBounds;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playText = Content.Load<Texture2D>("ballFace");
            coinText = Content.Load<Texture2D>("Coin");
            badGuyText = Content.Load<Texture2D>("redEye");
            wallText = Content.Load<Texture2D>("Rockwall");
            font = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState kState = Keyboard.GetState();
            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                if (kState.IsKeyDown( Keys.A))
                    screen = Screen.Game;
            }
            else if (screen == Screen.Game)
            {
                phit = player.PlayHitbyBady(player.PlayerBounds, badguy.BadBounds);bhit= badguy.BadTopHit(badguy.BadBounds, player.PlayerBounds);
                player.Move(_graphics, kState);
                badguy.Move(_graphics);
                if(callerl==(0,gPH))
            }
            else if (screen == Screen.End)
            {
                if (kState.IsKeyDown(Keys.A))
                    this.Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if(screen==Screen.Intro)
            {

            }
            else if(screen== Screen.Game)
            {
                if (phit == false)
                {
                    player.Draw(_spriteBatch);
                    _spriteBatch.DrawString(font, lives.ToString(), new Vector2(0, 0), Color.Blue);
                }
                else
                {
                    callerl =new Point(0, gPH);                    
                    lives --;
                    _spriteBatch.DrawString(font, lives.ToString(), new Vector2(0, 0), Color.Blue);
                }
                if(bhit==false)
                badguy.Draw(_spriteBatch);
            }
            else if(screen== Screen.End)
            {

            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}