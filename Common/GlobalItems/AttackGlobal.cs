
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Runic.Content.Imbues;
using Runic.Common.Players;
using Runic.Content.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


//using Runic.Common.Players;

namespace Runic.Common.GlobalItems
{
    // use this as a template for all imbues

    
    public class Attack : GlobalItem
    {


        public virtual bool CanUseiten(Terraria.Player player, Item item)
        {

            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();

            if (item.prefix == ModContent.PrefixType<Infamous>())
            {







                if (modPlayer.SoulCurrent < 2)
                {



                    return true;




                }



                else
                {


                    return false;


                }





            }

            return true;        
        
        }


        public override bool Shoot(Item item, Terraria.Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();




            if (item.prefix == ModContent.PrefixType<Infamous>())// && item.useStyle == ItemUseStyleID.Thrust)

            {
                



                if (player.controlUseItem) { 
                
                
                
                    modPlayer.SoulCurrent = -2;
                
                
                
                }







            }







            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }





        public override bool AltFunctionUse(Item item, Terraria.Player player)
        {
            if (item.prefix == ModContent.PrefixType<Infamous>()) //makes sure non special prefixed items dont have an alt use 
            {

                return true;
            }

            return false;
        }




    }


}
       