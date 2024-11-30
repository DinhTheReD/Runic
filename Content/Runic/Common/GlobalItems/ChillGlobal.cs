
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





                        SoundEngine.PlaySound(new SoundStyle("Runic/Assets/Sounds/Chill_Shot"));






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
       