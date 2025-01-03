using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Mono.Cecil;

namespace Runic.Content.Projectiles
{
	public class ThrownTile: ModProjectile
	{
		public Item ItemChosen = default;
        public Tile targetile = default;
        public Vector2 ownerlastposition = Vector2.Zero;
        public int DustType = 0;
		public const int TotalDuration = 3600;
        public bool inrangelastupdate = false;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lightning Arc"); // Name of the projectile. It can be appear in chat
		}
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.hide = false;
			Projectile.friendly = true;
			Projectile.aiStyle = 0;
			Projectile.timeLeft = TotalDuration;
			Projectile.penetrate = 100;
			Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 30;

        }
        public override void OnSpawn(IEntitySource source)
        {
            base.OnSpawn(source);
            Vector2 tilelocation = Vector2.Zero;
            tilelocation.X = (int)(Projectile.position.X / 16);
            tilelocation.Y = (int)(Projectile.position.Y / 16);
            targetile = Main.tile[(int)tilelocation.X, (int)tilelocation.Y];
            if (targetile.HasTile)
            {
                for (int i = 0 ; i < ItemLoader.ItemCount; i++)
                {                    
                    if (ContentSamples.ItemsByType[i].createTile == targetile.TileType && ContentSamples.ItemsByType[i].consumable == true)
                    {
                        ItemChosen = ContentSamples.ItemsByType[i];
                        /* This is code to outline the selected tiled with some dust. I think this visual works better if the tiles chosen aren't player-selected */
                        Vector2 Blockedge = Projectile.position;
                        Blockedge.X -= Projectile.position.X % 16;
                        Blockedge.Y -= Projectile.position.Y % 16;
                        for (int k = 0; k < 16; k++)
                        {
                            int num797 = Dust.NewDust(Blockedge + k * Vector2.UnitX, 2, 2, DustID.IceTorch, 0f, 0f, 100, default, 1.1f);
                            Main.dust[num797].noGravity = true;
                            Main.dust[num797].velocity *= 0f;
                            int num798 = Dust.NewDust(Blockedge + k * Vector2.UnitY, 2, 2, DustID.IceTorch, 0f, 0f, 100, default, 1.1f);
                            Main.dust[num798].noGravity = true;
                            Main.dust[num798].velocity *= 0f;
                            int num799 = Dust.NewDust(Blockedge + k * Vector2.UnitX + 16 * Vector2.UnitY, 2, 2, DustID.IceTorch, 0f, 0f, 100, default, 1.1f);
                            Main.dust[num799].noGravity = true;
                            Main.dust[num799].velocity *= 0f;
                            int num796 = Dust.NewDust(Blockedge + k * Vector2.UnitY + 16 * Vector2.UnitX, 2, 2, DustID.IceTorch, 0f, 0f, 100, default, 1.1f);
                            Main.dust[num796].noGravity = true;
                            Main.dust[num796].velocity *= 0f;
                        }
                        
                        /**/
                        break;
                    }
                }
                if (ItemChosen != null)
                {
                    if (ItemChosen == default)
                    {
                        Projectile.active = false;
                    }
                    Projectile.Name = "Thrown" + ItemChosen.Name;
                }
                else Projectile.active = false;
            }
			else
			{
				Projectile.active = false;
			}
        }
        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (inrangelastupdate) //We do this so that the player can't run away from their shield once it's formed
            {
                Projectile.Center += (owner.Center - ownerlastposition);
                inrangelastupdate = false;
            }
            Vector2 OldVel = Projectile.velocity;
            Projectile.velocity = owner.Center - Projectile.Center;
            if (Projectile.velocity.Length() < 75) //Give the projectiles a bit of "stickiness" to keep them near the player
            {
                inrangelastupdate = true;
                ownerlastposition = owner.Center;
            }
            if (Projectile.velocity.Length() < 65) //It's gotten near enough to the player, time to orbit.
            {
                Vector2 NewTarg = (Projectile.Center - owner.Center).RotatedBy(Math.PI / 180 * 3) + owner.Center;
                Projectile.velocity = NewTarg - Projectile.Center;
            }
            Projectile.velocity = Projectile.velocity.SafeNormalize(Vector2.Zero);
            Projectile.velocity *= OldVel.Length();
			Projectile.rotation += (float)Math.PI / 180 * 3;
            if (Projectile.timeLeft % (12 + owner.ownedProjectileCounts[Projectile.type]) == 0)
            {
                int ProjID = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<LightningArcVisual>(), 0, 0f, owner.whoAmI);
                Projectile proj = Main.projectile[ProjID];
                proj.ai[0] = owner.Center.X;
                proj.ai[1] = owner.Center.Y;
                proj.scale = 0.67f;
                WorldGen.KillTile_MakeTileDust((int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16), targetile);
            }
        }
        public override void OnKill(int timeLeft)
        {
            WorldGen.KillTile_MakeTileDust((int)(Projectile.position.X / 16), (int)(Projectile.position.Y / 16), targetile);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            //Texture2D Tex = (Texture2D)TextureAssets.Item[12]; Can use this to retrieve the texture of an item given its type.
            // Getting texture of projectile
            Texture2D guntexture = (Texture2D)TextureAssets.Item[ItemChosen.type];
            // Calculating frameHeight and current Y pos dependence of frame
            // If texture without animation frameHeight is always texture.Height and startY is always 0
            int gunframeHeight = guntexture.Height / Main.projFrames[Projectile.type];
            int gunstartY = gunframeHeight * Projectile.frame;
            // Get this frame on texture
            Rectangle gunsourceRectangle = new Rectangle(0, gunstartY, guntexture.Width, gunframeHeight);
            // Alternatively, you can skip defining frameHeight and startY and use this:
            // Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Projectile.type], frameY: Projectile.frame);
            Vector2 gunorigin = gunsourceRectangle.Size() / 2f;
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(guntexture, Projectile.Center - Main.screenPosition, gunsourceRectangle, drawColor, Projectile.rotation, gunorigin, 1f, SpriteEffects.None, 0);
            // It's important to return false, otherwise we also draw the original texture.
            return false;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Make this always hit enemies away from the player, like a flail, so it works better as a barrier.
            modifiers.HitDirectionOverride = (Main.player[Projectile.owner].Center.X < target.Center.X).ToDirectionInt();
        }
    }
}