﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;



namespace Runic.Content.Items.Consumables
{



    public class DMRune_Inert : ModItem
    {





        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;// who the fuck actaully uses this mode?





        }



        public override void SetDefaults()
        {
            Item.height = 20; 
            Item.width = 20;
           
            Item.rare = ItemRarityID.Quest;
            Item.useStyle = ItemUseStyleID.HoldUp; // yeah you really should  
















        }







    }


}