using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Topic_3___Animation
{
    enum Screen
    {
        Intro,
        TribbleYard,
        EndScreen
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D greyTexture, brownTexture, creamTexture, orangeTexture, introTexture, endTexture;
        Rectangle greyRect, creamRect, orangeRect, brownRect;
        Vector2 greyTribbleSpeed, creamSpeed, orangeSpeed, brownSpeed;
        float timer;
        Rectangle window;

        Screen screen;

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //grey
            greyRect = new Rectangle(300, 10, 100, 100);
            greyTribbleSpeed = new Vector2(2, 2);
            //cream
            creamRect = new Rectangle(200, 40, 100, 100);
            creamSpeed = new Vector2(0, 3);
            //brown
            brownRect = new Rectangle(400, 150, 100, 100);
            brownSpeed = new Vector2(2, 4);
            //orange 
            orangeRect = new Rectangle(250, 300, 100, 100);
            orangeSpeed = new Vector2(2, 0);
            window = new Rectangle(0, 0, 800, 600);


            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            introTexture = Content.Load<Texture2D>("Untitled");
            greyTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTexture = Content.Load<Texture2D>("tribbleBrown");
            orangeTexture = Content.Load<Texture2D>("tribbleOrange");
            creamTexture = Content.Load<Texture2D>("tribbleCream");
            endTexture = Content.Load<Texture2D>("end screen");
            timer = 15f;
        }

        protected override void Update(GameTime gameTime)
        {

            

            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed) 
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                // TODO: Add your update logic here

                //grey
                greyRect.X += (int)greyTribbleSpeed.X;
                if (greyRect.Right > window.Width || greyRect.Left < 0)
                    greyTribbleSpeed.X *= -1;

                greyRect.Y += (int)greyTribbleSpeed.Y;
                if (greyRect.Top < 0)
                    greyTribbleSpeed.Y = 2;
                else if (greyRect.Bottom > window.Height)
                    greyTribbleSpeed.Y = -2;

                //cream
                creamRect.X += (int)creamSpeed.X;
                if (creamRect.Right > window.Width || creamRect.Left < 0)
                    creamRect.X *= -1;

                creamRect.Y += (int)creamSpeed.Y;
                if (creamRect.Top < 0)
                    creamSpeed.Y = 3;
                else if (creamRect.Bottom > window.Height)
                    creamSpeed.Y = -3;
                //brown
                brownRect.X += (int)brownSpeed.X;
                if (brownRect.Right > window.Width || brownRect.Left < 0)
                    brownSpeed.X *= -1;

                brownRect.Y += (int)brownSpeed.Y;
                if (brownRect.Top < 0)
                    brownSpeed.Y = 4;
                else if (brownRect.Bottom > window.Height)
                    brownSpeed.Y = -4;
                //orange
                orangeRect.X += (int)orangeSpeed.X;
                if (orangeRect.Right > window.Width || orangeRect.Left < 0)
                    orangeSpeed.X *= -1;
                //clock
                timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

            



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            

            _spriteBatch.Begin();
            if (timer < 0f)
            {
                screen = Screen.EndScreen;
                if (screen == Screen.EndScreen)
                {
                    _spriteBatch.Draw(endTexture, window, Color.White);
                }
            }
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
            _spriteBatch.Draw(greyTexture, greyRect, Color.White);
            _spriteBatch.Draw(creamTexture, creamRect, Color.White);
            _spriteBatch.Draw(brownTexture, brownRect, Color.White);
            _spriteBatch.Draw(orangeTexture, orangeRect, Color.White);
            }


            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
