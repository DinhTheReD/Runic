using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

using Runic.Content.Imbues;
using System.Data;

namespace Runic.Common.GlobalItems
{
    // use this as a template for all imbues

    // works roughly how it should right now come back to to fix later
    // i need to take into account of weapons that are tecnhally projectiles
/*
    public class Beeim : GlobalItem
    {

      

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);

            

        }

        public override bool AltFunctionUse(Item item, Player player)
        {
            if (item.prefix == ModContent.PrefixType<Beeimb>()) //makes sure non special prefixed items dont have an alt use 
            {

                return true;
            }

            return false;   
        }



        public override bool CanUseItem(Item item, Player player)
        {

            

            if (item.prefix == ModContent.PrefixType<Beeimb>()) 
            {
               

                if (player.altFunctionUse == 2)
                {

                    // a little fucky,  okay it just stright up overwrites the items stats keep this in mind

                 
                    
                    item.shoot = ProjectileID.Bee;
                    

                }


                




                else
                {
                    //alright fine i think i might just have to stick to only having projectiles on alt use and not them modfiy the weapons stats directly
                    // item.useStyle = 1 ;
                    
                    item.shoot = ProjectileID.None;
                
                
                }

                
                return true;

                
            }



            

            item.shoot = ProjectileID.None;
            return base.CanUseItem(item, player);

           
        
        }





    } */ 
}

       