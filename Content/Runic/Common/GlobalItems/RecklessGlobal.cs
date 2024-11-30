
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Runic.Content.Imbues;
using Runic.Common.Players;
using Runic.Content.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Drawing.Drawing2D;


//using Runic.Common.Players;

namespace Runic.Common.GlobalItems
{
    // use this as a template for all imbues



    public class Reckdash : ModPlayer
    {

        //   public const int DashDown = 0;
        //  public const int DashUp = 1;
        public const int DashRight = 2;
        public const int DashLeft = 3;




        public const int DashCD = 30; // cooldown

        public const int DashDur = 30; // durartion

        public const float DashVel = 15f; // velocity 



        public int DashDir = -1;


        public int DashDelay = 0;
        public int DashTimer = 0;

        public bool DashAccessoryEquipped;

      





        public override void ResetEffects()
        {
            // Reset our equipped flag. If the accessory is equipped somewhere, ExampleShield.UpdateAccessory will be called and set the flag before PreUpdateMovement
            DashAccessoryEquipped = false;
            // ResetEffects is called not long after player.doubleTapCardinalTimer's values have been set
            // When a directional key is pressed and released, vanilla starts a 15 tick (1/4 second) timer during which a second press activates a dash
            // If the timers are set to 15, then this is the first press just processed by the vanilla logic.  Otherwise, it's a double-tap


            if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15 )
            {
                DashDir = DashRight;
               
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
            {
                DashDir = DashLeft;
               
            }
            else
            {
                DashDir = -1;
            }
        }

        // This is the perfect place to apply dash movement, it's after the vanilla movement code, and before the player's position is modified based on velocity.
        // If they double tapped this frame, they'll move fast this frame
        public override void PreUpdateMovement()
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();

            // if the player can use our dash, has double tapped in a direction, and our dash isn't currently on cooldown
            if (CanUseDash() && DashDir != -1 && DashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (DashDir)
                {
                    // Only apply the dash velocity if our current speed in the wanted direction is less than DashVelocity

                    case DashLeft when Player.velocity.X > -DashVel:
                    case DashRight when Player.velocity.X < DashVel:
                        {
                            // X-velocity is set here
                            float dashDirection = DashDir == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVel;
                            break;
                        }
                    default:
                        return; // not moving fast enough, so don't start our dash
                }

                // start our dash
                DashDelay = DashCD;
                DashTimer = DashDur;
                Player.velocity = newVelocity;
                modPlayer.SoulCurrent = modPlayer.SoulCurrent - 5;
                // Here you'd be able to set an effect that happens when the dash first activates
                // Some examples include:  the larger smoke effect from the Master Ninja Gear and Tabi
            }

            if (DashDelay > 0)
                DashDelay--;

            if (DashTimer > 0)
            { // dash is active
              // This is where we set the afterimage effect.  You can replace these two lines with whatever you want to happen during the dash
              // Some examples include:  spawning dust where the player is, adding buffs, making the player immune, etc.
              // Here we take advantage of "player.eocDash" and "player.armorEffectDrawShadowEOCShield" to get the Shield of Cthulhu's afterimage effect
                Player.eocDash = DashTimer;
                Player.armorEffectDrawShadowEOCShield = true;
               
                // count down frames remaining
                DashTimer--;
            }
        }

        private bool CanUseDash()
        {

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();

            if (Player.HeldItem.prefix == ModContent.PrefixType<Reckless>() && modPlayer.SoulCurrent >= 5  ) {

              
                return true;


            }
            
           
            
            
            
            return false;
            
            
            
            
            
            
            //DashAccessoryEquipped
                         // && Player.dashType == DashID.None // player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
                         //&& !Player.setSolar // player isn't wearing solar armor
                         // && !Player.mount.Active; // player isn't mounted, since dashes on a mount look weird
        }



    }
























    public class RecklessGlobal : GlobalItem
    {



        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);


            if (item.shoot == ProjectileID.None) 
            
            
            {
                // add a projectile that does noting so adding a new seprate effect works and doesnt fuck with things that already have one

                item.shoot = ModContent.ProjectileType<DummyProj>();




            }



        }





        public override bool Shoot(Item item, Terraria.Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();

            


            if (item.prefix == ModContent.PrefixType<Chilled>())// && item.useStyle == ItemUseStyleID.Thrust)

            {

                




                if  (item.shoot == ModContent.ProjectileType<DummyProj>())
                {


                   


                    if (player.altFunctionUse == 2 && modPlayer.SoulCurrent < 5)
                    {


                    

                        return false;


                    }





                    if (player.altFunctionUse == 2 && modPlayer.SoulCurrent >= 5)
                    {


                        modPlayer.SoulCurrent = modPlayer.SoulCurrent - 5;


                        

                        Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ChillProj>(), damage, knockback, player.whoAmI);





                      //  SoundEngine.PlaySound(new SoundStyle("Runic/Assets/Sounds/Chill_Shot"));
                      //need sash sound






                    }






                }




                if (player.altFunctionUse == 2 && modPlayer.SoulCurrent < 5)
                {



                    return false;


                }





                if (player.altFunctionUse == 2 && modPlayer.SoulCurrent >= 5)
                {


                    modPlayer.SoulCurrent = modPlayer.SoulCurrent - 5;



                    



                    Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<ChillProj>(), damage, knockback, player.whoAmI);



                    SoundEngine.PlaySound(new SoundStyle("Runic/Assets/Sounds/Chill_Shot"));






                }






            }







            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }





        public override bool AltFunctionUse(Item item, Terraria.Player player)
        {
            if (item.prefix == ModContent.PrefixType<Chilled>()) //makes sure non special prefixed items dont have an alt use 
            {

                return true;
            }

            return false;
        }






     




    }


}
       