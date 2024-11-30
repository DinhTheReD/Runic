using Runic.Content.Damageclass;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.ID;




namespace Runic.Content.Projectiles
{
    public class ChillProj : ModProjectile
    {

        Vector2 lastCursorPos;



        public override void SetDefaults()
        {

            Projectile.arrow = false;
            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<RunicDamage>();
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.rotation = 0;
            Projectile.netImportant = true;

        }


        public override void AI()
        {
            

            // In Multi Player (MP) This code only runs on the client of the projectile's owner, this is because it relies on mouse position, which isn't the same across all clients.
            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {

                Player player = Main.player[Projectile.owner];
                // If the player channels the weapon, do something. This check only works if item.channel is true for the weapon.
                if (player.channel)
                {
                    float maxDistance = 18f; // This also sets the maximun speed the projectile can reach while following the cursor.
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    // Here we can see that the speed of the projectile depends on the distance to the cursor.
                    if (distanceToCursor > maxDistance)
                    {
                        distanceToCursor = maxDistance / distanceToCursor;
                        vectorToCursor *= distanceToCursor;
                    }

                    int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
                    int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 1000f);
                    int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
                    int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 1000f);

                    // This code checks if the precious velocity of the projectile is different enough from its new velocity, and if it is, syncs it with the server and the other clients in MP.
                    // We previously multiplied the speed by 1000, then casted it to int, this is to reduce its precision and prevent the speed from being synced too much.
                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    {
                        Projectile.netUpdate = true;
                    }

                    Projectile.velocity = vectorToCursor;

                }
                // If the player stops channeling, do something else.
                else if (Projectile.ai[0] == 0f)
                {

                    // This code block is very similar to the previous one, but only runs once after the player stops channeling their weapon.
                    Projectile.netUpdate = true;

                    float maxDistance = 14f; // This also sets the maximun speed the projectile can reach after it stops following the cursor.
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    //If the projectile was at the cursor's position, set it to move in the oposite direction from the player.
                    if (distanceToCursor == 0f)
                    {
                        vectorToCursor = Projectile.Center - player.Center;
                        distanceToCursor = vectorToCursor.Length();
                    }

                    distanceToCursor = maxDistance / distanceToCursor;
                    vectorToCursor *= distanceToCursor;

                    Projectile.velocity = vectorToCursor;

                    if (Projectile.velocity == Vector2.Zero)
                    {
                        Projectile.Kill();
                    }

                    Projectile.ai[0] = 1f;
                }
            }

            // Set the rotation so the projectile points towards where it's going.
            if (Projectile.velocity != Vector2.Zero)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
            }
        }

       

         

            /*

            Vector2 Oldpos;
            float Dis2cur = lastCursorPos.Length(); //distance to cursor
            Player player = Main.player[Projectile.owner];

            if (Projectile.ai[0] == 0 ) {


                if (Main.mouseRight)
                {

                    lastCursorPos = Main.MouseWorld;




                }

                


                Vector2 direction = lastCursorPos - Projectile.Center;
                
               
                direction.Normalize();
                Projectile.velocity = direction * 8;
                


                if (Main.mouseLeft)
                {
                    

                    Projectile.velocity = Projectile.velocity + direction;


                    //lastCursorPos = Projectile.Center - player.Center;
                    Dis2cur = lastCursorPos.Length();





                }

               


            }


            if (Projectile.ai[0] == 1)
            {


                

                // do other thing



            }



            
            Projectile.rotation = Projectile.velocity.ToRotation();
            Lighting.AddLight(Projectile.Center, 0.0f, 0.0f, 0.4f);



        }


        


        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(new SoundStyle("Runic/Assets/Sounds/Chill_Hit"));
        }







    }


    /*

            i like the way this works and want to use it for something else like a slow moving aoe attack

          public override void AI()
            {

                Vector2 cursorPos = new(Main.mouseX, Main.mouseY);

                if (Main.mouseRight)
                {

                    lastCursorPos = Main.MouseWorld;


                }







                Vector2 direction = lastCursorPos - Projectile.Center;
                // Vector2 direction = cursorPos - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = direction * 8;




                Projectile.rotation = Projectile.velocity.ToRotation();
                Lighting.AddLight(Projectile.Center, 0.0f, 0.0f, 0.4f);










            }

        







     */



        }
    }












