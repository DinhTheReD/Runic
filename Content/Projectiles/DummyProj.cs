using Runic.Content.Damageclass;
using System.Numerics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace Runic.Content.Projectiles
{
    public class DummyProj : ModProjectile
    {


      

        public override void SetDefaults()
        {
            
            Projectile.arrow = false;
            Projectile.width = 0;
            Projectile.height = 0;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<RunicDamage>();
            Projectile.timeLeft = 0;
          
            Projectile.ignoreWater = true;

            Projectile.rotation = 0;
            

        }
    /*
        public override void AI()

        {

            Projectile.velocity = new Vector2(2,2);




        }

        */

//        public override void OnTileCollide(Vector2 oldVelocity) { 
  //      
         //       Projectile.Kill();
    ///    
        
       // }



       

   
        


    }
}