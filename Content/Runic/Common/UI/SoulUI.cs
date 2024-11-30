using Runic.Common.Players;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Runic.Content.Buffs;

// this was just a quick hack job to lean how to learn how to go about making a ui 

namespace Runic.Common.UI
{
    internal class SoulBar : UIState
    {

        private UIText text;
        private UIElement area;
        private UIImage barFrame;
        private UIImage Sfill;
        private Color gradientA;
        private Color gradientB;





       //i have no fucking clue what im doing
       //this doesnt bode well for , well anything
       // holy fuck i need to clean this shit up but it works for now




        public override void OnInitialize()
        {

            
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 60, 1f);
            area.Top.Set(13, 0f);
            area.Width.Set(40, 0f);
            area.Height.Set(264, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("Runic/Common/UI/dot")); // drawing the backplates
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0);
            barFrame.Width.Set(38, 0f);
            barFrame.Height.Set(264, 0f);

            Sfill = new UIImage(ModContent.Request<Texture2D>("Runic/Common/UI/soulbar2"));



            text = new UIText("", 0.8f); // the localization file actaully dictates whats printed on the screen
            text.Width.Set(0, 0f);
            text.Height.Set(0, 0f);
            text.Top.Set(264, 0);
            text.Left.Set(-12, 0f);

            gradientA = new Color(0, 300, 138);
            gradientB = new Color(0, 250, 201);



            area.Append(text);
            area.Append(barFrame);
            Append(area);



            


        }
        
        
        
        
        public override void Draw(SpriteBatch spriteBatch)
        {


            if (Main.LocalPlayer.HasBuff<FrostBorne>() == true)
            {



                base.Draw(spriteBatch);

               

            }

            //  return;
            // spriteBatch.End(barFrame);

        }



        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();

            float quotient = (float)modPlayer.SoulCurrent / modPlayer.SoulMax2;
            quotient = Utils.Clamp(quotient, 0f, 1f);


            // Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            hitbox.X += 6;
            hitbox.Width = 108;
            hitbox.Y += 8;
            hitbox.Height = 130;
            Color color = Color.White;
            // Sfill.Draw(spriteBatch);

          
            spriteBatch.Draw((Texture2D)ModContent.Request<Texture2D>("Runic/Common/UI/soulbar2"), new Vector2(hitbox.X - 10,hitbox.Y - 10), color);

           


            int left = hitbox.Left;
            int right = hitbox.Right;
            int steps = (int)((right - left) * quotient);

            for (int i = 0; i < steps; i += 1)
            {
                float percent = (float)i / (right + left);
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(hitbox.Left, hitbox.Height - i, hitbox.Width - 90, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }

        }

      
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public override void Update(GameTime gameTime)
        {
           

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();
            // Setting the text per tick to update and show our resource values.
            text.SetText(SoulUISystem.SoulText.Format(modPlayer.SoulCurrent, modPlayer.SoulMax2));
            base.Update(gameTime);

        }








        // This class will only be autoloaded/registered if we're not loading on a server
        [Autoload(Side = ModSide.Client)]
        internal class SoulUISystem : ModSystem
        {
            private UserInterface SoulBarUserInterface;

            internal SoulBar SoulBar;

            public static LocalizedText SoulText { get; private set; }

            public override void Load()
            {
                SoulBar = new();
                SoulBarUserInterface = new();
                SoulBarUserInterface.SetState(SoulBar);

                string category = "UI";
                SoulText ??= Mod.GetLocalization($"{category}.SoulResource");
            }

            public override void UpdateUI(GameTime gameTime)
            {
                SoulBarUserInterface?.Update(gameTime);






            }





            public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
            {
                
                
                
                int SoulBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
                if (SoulBarIndex != -1)
                {
                    layers.Insert(SoulBarIndex, new LegacyGameInterfaceLayer(
                        "Runic: Soul",
                        delegate
                        {
                            SoulBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                            return true;
                        },
                        InterfaceScaleType.UI)
                    );

                }

            }



        }

    
    
    
    
    
    
          
    
    
    
    
    }


    // unsure if this is a good way of going about drawing the soul bar










}


/*
 * 
 * int top = hitbox.Top;
int bottom = hitbox.Bottom;
int steps = (int)((bottom - top) * quotient);
for (int i = 0; i < steps; i += 1)
{
    float percent = (float)i / steps;
    int y = top + (int)(percent * (bottom - top));
    spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(hitbox.X, y, hitbox.Width, 1), Color.Lerp(gradientA, gradientB, percent));
}

*/
