
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

using Runic.Content.Damageclass;

namespace Runic.Content.Imbues
{

    // better then ledgendary but costs much more soul. still boring 
    

    public class Eminent : ModPrefix {

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 100f;
        }

        public override void Apply(Item item)
        {
            




           // item.shootSpeed = 10f; // the shot speed seems to have to be tied to the weapon 

          




            







        }








        public override bool CanRoll(Item item)
        {
            return false;
        }






    }



}


