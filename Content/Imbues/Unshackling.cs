
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Runic.Content.Damageclass;

namespace Runic.Content.Imbues
{


    //cause a debuff on a mob that creates a wisp that darts around it attacking the hard to hit wisp deals more (runic?) damage


    public class Unshackling : ModPrefix {

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


