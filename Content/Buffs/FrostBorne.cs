using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using Terraria.Localization;


namespace Runic.Content.Buffs
{
    public class FrostBorne : ModBuff
    {
       
        

        //make imbues check if the player has the buff otherwise debuff / hurt the player on use

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = true;
            Main.persistentBuff[Type] = true;
            


        }




        public override void Update(Player player, ref int buffIndex) {
            player.resistCold = true;
            player.buffImmune[47] = true;
            player.buffImmune[46] = true;
            player.statManaMax2 = 0;

            if (player.statManaMax2 != 0) // well shit I guess this fixes my UI debacle
            {
                player.statManaMax2 = 0;
            }

            // these immuneitys are mostly for flavor ill remove them if people see them as too broken
            // maybe make it a config option 
           

        }












    }


}
