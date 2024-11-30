
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Runic.Content.Damageclass;

namespace Runic.Content.Imbues
{


    //drains the players soul and when it hits zero the player dies and releases a number of projectiles based on how kmuch damage they did


    public class Desperate : ModPrefix {

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


