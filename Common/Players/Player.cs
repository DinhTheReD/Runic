using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Runic.Content.Buffs;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;

namespace Runic.Common.Players
{



    public partial class Player : ModPlayer // eyecolor change change name later
    {


        public override void OnHitAnything(float x, float y, Entity victim)
        {
            base.OnHitAnything(x, y, victim);
            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();




            if (Main.LocalPlayer.HasBuff<FrostBorne>() == true && modPlayer.SoulCurrent < modPlayer.SoulMax2)
            {


                // need to balance they return value
                modPlayer.SoulCurrent++;
            }




        }




        public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
        {
            



            if (Main.LocalPlayer.HasBuff<FrostBorne>() == true)
            {
              


                // Player.eyeColor = Color.DarkBlue;

                // drawInfo.colorEyes = new Color(20,330,80);

                drawInfo.colorEyes = new Color(20,330,80);


                drawInfo.colorEyeWhites = new Color(200, 400, 300); // i think the vlues are inverted

                // fuck whith this a bit more  and  set up the alt values






            }




            
       

        
        
        
        }




        










    }

}




/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *    public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo) {
            if (!Main.gameMenu && Player.HeldItem.ModItem is ItemHooks.IPreDrawPlayer preDrawPlayer) {
                preDrawPlayer.PreDrawPlayer(Player, this, ref drawInfo);
            }
            if (Player.front > 0 && Player.front == PumpkingCloak.FrontID) {
                drawInfo.hidesBottomSkin = true;
                drawInfo.hidesTopSkin = true;
            }
            if (stackingHat > 0 && StackingHatEffect.Blacklist.Contains(drawInfo.drawPlayer.head)) {
                stackingHat = 0;
            }
            if (stackingHat > 0) {
                drawInfo.hideHair = false;
                drawInfo.fullHair = true;
                drawInfo.hatHair = true;
            }
            if (eyeGlint) {
                drawInfo.colorEyeWhites = Color.White;
                drawInfo.colorEyes = drawInfo.drawPlayer.eyeColor;
            }
            if (CustomDrawShadow != null) {
                drawInfo.shadow = CustomDrawShadow.Value;
                float val = 1f - CustomDrawShadow.Value;
                drawInfo.colorArmorBody *= val;
                drawInfo.colorArmorHead *= val;
                drawInfo.colorArmorLegs *= val;
                drawInfo.colorBodySkin *= val;
                drawInfo.colorElectricity *= val;
                drawInfo.colorEyes *= val;
                drawInfo.colorEyeWhites *= val;
                drawInfo.colorHair *= val;
                drawInfo.colorHead *= val;
                drawInfo.colorLegs *= val;
                drawInfo.colorMount *= val;
                drawInfo.colorPants *= val;
                drawInfo.colorShirt *= val;
                drawInfo.colorShoes *= val;
                drawInfo.colorUnderShirt *= val;
                drawInfo.ArkhalisColor *= val;
                drawInfo.armGlowColor *= val;
                drawInfo.bodyGlowColor *= val;
                drawInfo.floatingTubeColor *= val;
                drawInfo.headGlowColor *= val;
                drawInfo.itemColor *= val;
                drawInfo.legsGlowColor *= val;
            }
            ModifyDrawInfo_Vampire(ref drawInfo);
        }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *   private void ModifyDrawInfo_Vampire(ref PlayerDrawSet drawInfo) {
            if (!IsVampire) {
                return;
            }

            float brightness = (drawInfo.colorEyes.R + drawInfo.colorEyes.G + drawInfo.colorEyes.B) / 255f;
            if (brightness < 0.2f) {
                brightness = 0.2f;
            }
            else if (brightness > 0.95f) {
                brightness = 0.95f;
            }
            drawInfo.colorEyes = Color.Lerp(drawInfo.colorEyes, new Color(255, 10, 10, drawInfo.colorEyes.A), brightness + (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 4f) * 0.05f));

            float skinSaturation = 0.5f;
            if (vampireDay) {
                skinSaturation /= 2f;
            }
            drawInfo.colorBodySkin = drawInfo.colorBodySkin.SaturationMultiply(skinSaturation);
            drawInfo.colorHead = drawInfo.colorHead.SaturationMultiply(skinSaturation);
            drawInfo.colorLegs = drawInfo.colorLegs.SaturationMultiply(skinSaturation);


*/
        