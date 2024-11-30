
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Runic.Content.Damageclass;

namespace Runic.Content.Imbues
{


    //shoot a projectile that can be hit ti refelct it back increasing its speed and damage
    // it peircees 
    // it has to alternate between runic and non runic damage to cause it to cause the reflect


    public class Vollying : ModPrefix {

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 100f;
        }

        public override void Apply(Item item)
        {
            //item.shoot = ProjectileID.Bee; make custom ia that uses rune damage


            // item.useStyle = ItemUseStyleID.HoldUp;

            // item.DamageType = ModContent.GetInstance<RunicDamage>(); // okay this works 

            // but how could i have it add an alt use




           // item.shootSpeed = 10f; // the shot speed seems to have to be tied to the weapon 

          




            if (item.prefix == ModContent.PrefixType<Beeimb>()) {




                
                
            }








        }








        public override bool CanRoll(Item item)
        {
            return true;
        }






    }



}


