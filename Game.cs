using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Pacote de UI
using GeonBit.UI;
using GeonBit.UI.Entities;

namespace MalditosGoblins.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameGoblin : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameGoblin()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.IsBorderless = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize the UI
            UserInterface.Initialize(Content, BuiltinThemes.hd);
            UserInterface.Active.IncludeCursorInRenderTarget = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            int screenHeight = GraphicsDevice.Viewport.Height;
            int screenWidth = GraphicsDevice.Viewport.Width;
            Panel background = new Panel(new Vector2(screenWidth, screenHeight));
            UserInterface.Active.AddEntity(background);

            Panel avatarPanel = new Panel(new Vector2(300, screenHeight/2), anchor: Anchor.TopLeft, skin: PanelSkin.Simple);
            background.AddChild(avatarPanel);
            Header title = new Header("A sua Coisinha Verde");
            title.Scale = 0.8f;
            avatarPanel.AddChild(title);
            avatarPanel.AddChild(new HorizontalLine());

            Panel skillPanel = new Panel(new Vector2(300, screenHeight / 2), anchor: Anchor.BottomLeft, skin: PanelSkin.Simple);
            background.AddChild(skillPanel);

            skillPanel.AddChild(new Header("Os paranaues"));
            skillPanel.AddChild(new HorizontalLine());
            PanelTabs panelTabs = new PanelTabs();
            panelTabs.SetAnchor(Anchor.BottomRight);
            panelTabs.BackgroundSkin = PanelSkin.Simple;
            panelTabs.Size = new Vector2(500, screenHeight / 2);
            panelTabs.Offset = new Vector2(10, 10);
            background.AddChild(panelTabs);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Lets Update de UI
            UserInterface.Active.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);

            // Lets draw de UI
            UserInterface.Active.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
