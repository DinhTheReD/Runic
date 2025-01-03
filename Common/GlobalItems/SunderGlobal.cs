
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


    public class Sunder : GlobalItem
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
            if (item.prefix == ModContent.PrefixType<Sundering>())
            {
                var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();
                int NewProjType = ModContent.ProjectileType<ChillProj>();
                SoundStyle NewSound = new SoundStyle("Runic/Assets/Sounds/Chill_Shot");
                if (player.altFunctionUse == 2 && modPlayer.SoulCurrent >= 5)
                {
                    item.holdStyle = 2;
                    player.itemTime = 120;
                    player.itemAnimation = 120;
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
