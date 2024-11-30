using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Runic.Content.Damageclass;

namespace Runic.Content.Items.Weapons
{

    public class MournBlade : ModItem
    {
     
        
       

            public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = ModContent.GetInstance<RunicDamage>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 20;
            Item.useStyle = 3;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;


        

       



        }





      

    } 

}


