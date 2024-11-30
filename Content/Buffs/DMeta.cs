using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using Terraria.Localization;


namespace Runic.Content.Buffs
{
    public class DMeta : ModBuff
    {
       //DAWK METAMORFIHSIF
        

        

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            BuffID.Sets.TimeLeftDoesNotDecrease[Type] = false;
            Main.persistentBuff[Type] = true;
            


        }




      
        












    }


}
