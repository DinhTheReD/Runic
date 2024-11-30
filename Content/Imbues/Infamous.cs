
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Runic.Content.Damageclass;

namespace Runic.Content.Imbues
{

   //boring copy of ledgenary consistant but costs soul to swing  
    

    public class Infamous : ModPrefix {

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 100f;
        }

        public override void Apply(Item item)
        {
            

          




            if (item.prefix == ModContent.PrefixType<Beeimb>()) {




                
                
            }








        }








        public override bool CanRoll(Item item)
        {
            return true;
        }






    }



}


