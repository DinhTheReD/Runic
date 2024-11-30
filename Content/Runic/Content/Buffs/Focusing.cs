using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using Terraria.Localization;
using System.Numerics;
using Terraria.GameContent.UI.ResourceSets;
using Microsoft.CodeAnalysis;
using Runic.Common.Players;


namespace Runic.Content.Buffs
{
    public class Focusing : ModBuff
    {
        // intill hardcoding a button inout the buff will have to do all the worr, this is gonna be such a bitch to balance
        // look up oh the update badhealth regen metodh does its math and have it drain soul over time
        
        

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = false;
            
            


        }



        

        public override bool ReApply(Terraria.Player player, int time, int buffIndex)
        {

            player.ClearBuff(ModContent.BuffType<Focusing>());

            return true;



        }







        public override void Update(Terraria.Player player, ref int buffIndex)
        {
            // arbatary numbers

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();
            player.GetModPlayer<FocusingPlayer>().Foucusing = true;
            player.moveSpeed = 0.001f;
            
            player.maxRunSpeed *= 0.25f;
            player.jumpSpeedBoost = -10;
            player.wingRunAccelerationMult = 0;
            modPlayer.SoulRegen = 1; //OH boy magical numbers!







            if (modPlayer.SoulCurrent < 1) {


                player.ClearBuff(ModContent.BuffType<Focusing>());


            }





            if (player.buffTime[buffIndex] == 0) { 
            
                player.statLife += player.statLifeMax2 /4;
            
                //heals 25% of max hp, look if its wrong fuck you
             
            
            }


            
                
        }

    }

    

    public class FocusingPlayer : ModPlayer
    {

        public bool Foucusing = false;
        

        public override void ResetEffects()
        {
            Foucusing = false;
        }

     

        public override void OnHurt(Terraria.Player.HurtInfo info)
        {

            Player.ClearBuff(ModContent.BuffType<Focusing>());
            
            
            base.OnHurt(info);
        
        
        
        }





        public override void PostUpdateRunSpeeds()
        {

            if (Foucusing)
            {

                Player.runAcceleration = 0;


            }
            
            
            }




    }











}
