
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Runic.Content.Imbues;
using Runic.Common.Players;
using Runic.Content.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


//using Runic.Common.Players;

namespace Runic.Common.GlobalItems
{
    // use this as a template for all imbues

    
    public class Chill : GlobalItem
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

        public override void ModifyShootStats(Item item, Terraria.Player player, ref Vector2 position, ref Vector2 velocity, ref System.Int32 type, ref System.Int32 damage, ref System.Single knockback)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();
            if (item.prefix == ModContent.PrefixType<Chilled>())
            {
                if (player.altFunctionUse == 2 && modPlayer.SoulCurrent >= 5 && modPlayer.SoulProjICD <= 0)
                {
                    modPlayer.SoulProjICD = item.useTime;
                    modPlayer.SoulCurrent = modPlayer.SoulCurrent - 5;
                    type = ModContent.ProjectileType<ChillProj>();
                    SoundEngine.PlaySound(new SoundStyle("Runic/Assets/Sounds/Chill_Shot"));
                }
            }
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
       