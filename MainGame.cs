using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Pacote de UI
using System;
using System.Collections.Generic;
using GeonBit.UI;
using GeonBit.UI.Entities;
using MalditosGoblins.Desktop.Goblin;

namespace MalditosGoblins.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<TabData> listTexts;
        Goblin.Goblin goblin;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.IsBorderless = true;
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();
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
            GoblinLoader.Instance.Load(Content);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadUIContent();
            ResetGoblin();
        }

        protected void ResetGoblin()
        {
            goblin = new Goblin.Goblin();
            for(int i = 0; i < goblin.skills.Count; i++)
            {
                listTexts[i].panel.Find<Header>("HeaderText").Text = goblin.skills[i].name + DateTime.Now.ToString("h:mm:ss tt");
                listTexts[i].panel.Find<Paragraph>("ParagraphText").Text = goblin.skills[i].description;
            }
        }

        protected void LoadUIContent()
        {
            int screenHeight = GraphicsDevice.Viewport.Height;
            int screenWidth = GraphicsDevice.Viewport.Width;
            Panel background = new Panel(new Vector2(screenWidth, screenHeight));
            background.Padding = new Vector2(10, 10);
            UserInterface.Active.AddEntity(background);

            Panel avatarPanel = new Panel(new Vector2(screenWidth / 3.5f, screenHeight / 2), anchor: Anchor.TopLeft, skin: PanelSkin.Simple);
            Header title = new Header("Sua Coisinha Verde");
            avatarPanel.AddChild(title);
            avatarPanel.AddChild(new HorizontalLine());
            background.AddChild(avatarPanel);

            Panel statusPanel = new Panel(new Vector2(screenWidth / 3.5f, screenHeight / 2), anchor: Anchor.BottomLeft, skin: PanelSkin.Simple);
            statusPanel.AddChild(new Header("Os paranaues"));
            statusPanel.AddChild(new HorizontalLine());
            background.AddChild(statusPanel);

            PanelTabs skillTabs = new PanelTabs();
            skillTabs.SetAnchor(Anchor.BottomRight);
            skillTabs.BackgroundSkin = PanelSkin.Simple;
            skillTabs.Size = new Vector2(screenWidth / 1.5f, screenHeight / 2);
            skillTabs.Offset = new Vector2(10, 10);
            background.AddChild(skillTabs);

            listTexts = new List<TabData>();
            for (int i = 1; i <= 3; i++) {
                TabData tab = skillTabs.AddTab("Nivel " + i);
                tab.button.ToolTipText = "Habilidade so pode ser utilizada no nivel " + i;
                tab.button.Size = new Vector2(tab.button.Size.X, 50);
                Header skillHeader = new Header("", anchor: Anchor.TopLeft);
                skillHeader.Identifier = "HeaderText";
                Paragraph skillText = new Paragraph("");
                skillText.Identifier = "ParagraphText";
                tab.panel.AddChild(skillHeader);
                tab.panel.AddChild(skillText);
                listTexts.Add(tab);
            }

            Button createGoblin = new Button("Recriar Goblin", anchor: Anchor.TopRight, offset: new Vector2(10, 10), size: new Vector2(screenWidth/3, 50));
            createGoblin.OnClick = (Entity btn) => { ResetGoblin(); };
            background.AddChild(createGoblin);
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
