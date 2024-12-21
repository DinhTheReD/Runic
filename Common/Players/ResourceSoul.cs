using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using Runic.Common.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


// this is just a rough copy of the example mod for now
// todo
// make it so you gain soul on hitting an hostile non critter entity by defauil[]
// save and load funtionality[x]
//tweak the resorce values for balance this is something for way later[]



namespace Runic.Common.Players
{

    public class ResourceSoul : ModPlayer
    {

        public int SoulCurrent;
        public const int DefaultSoulMax = 20;
        public int SoulMax;
        public int SoulMax2;
        public int GrandSouls; //lets see if i can tie saving to the resorce object i can \o/
        public static readonly int MaxGrandSouls = 4;
        public static readonly int MaxPerGrand = 20;
        public float SoulRegen;
        internal int SoulRegenTimer = 0;
        public static readonly Color Recover = new Color(200, 200, 20);




     



        public override void Initialize()
        {
            SoulMax = DefaultSoulMax;
          

        }

        public override void ResetEffects()
        {
            ResetVariables();
        }


        public override void UpdateDead()
        {
            ResetVariables();
        }




        private void ResetVariables()
        {
            SoulRegen = 0f; // you need to hit things to regen soul
            SoulMax2 = SoulMax + MaxPerGrand * GrandSouls;
            
            
        }


        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        public override void PostUpdate()
        {
            CapResourceGodMode();
        }

        private void UpdateResource()
        {

            SoulRegenTimer++;

            if (SoulRegenTimer > 60 / SoulRegen)
            {
                SoulCurrent -= 1;
                SoulRegenTimer = 0;
                
            }

            SoulCurrent = Utils.Clamp(SoulCurrent, 0, SoulMax2);

            


        }


        private void CapResourceGodMode()
        {
            if (Main.myPlayer == Player.whoAmI && Player.creativeGodMode)
            {
                SoulCurrent = SoulMax2;
            }






        }

        public override void SaveData(TagCompound tag)
        {
            tag["GrandSouls"] = GrandSouls;
            
        }



        public override void LoadData(TagCompound tag)
        {
            GrandSouls = tag.GetInt("GrandSouls");
          
        }







    }


   






}