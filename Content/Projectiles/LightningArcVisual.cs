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

namespace Runic.Content.Projectiles
{
	public class LightningArcVisual: ModProjectile
	{

		public const int TotalDuration = 600;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lightning Arc"); // Name of the projectile. It can be appear in chat
		}
		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.hide = true;
			Projectile.friendly = false;
			Projectile.aiStyle = 0;
			Projectile.MaxUpdates = 60;
			Projectile.timeLeft = TotalDuration;
			Projectile.penetrate = 1;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.damage = 0;
			Projectile.scale = 1.16f;
		}

		public override void AI()
		{
				for (int k = 0; k < 12; k++) //Leave 12 dusts over its movement from the previous frame
				{
					int num797 = Dust.NewDust(Projectile.Center - Projectile.velocity * (k/12), 0, 0, DustID.IceTorch, 0f, 0f, 100, default, Projectile.scale);
					Main.dust[num797].noGravity = true;
				Main.dust[num797].velocity *= 0f;

			}

				Vector2 target = new Vector2(Projectile.ai[0], Projectile.ai[1]); //Get the target spot we saved in the projectile AI
				Vector2 distancetotarget = target - Projectile.Center; //And the distance to the target
				Projectile.velocity += distancetotarget.RotatedByRandom(MathHelper.PiOver2);
				while (Projectile.velocity.Length() > 3f)
                {
					Projectile.velocity *= .97f;
                }
			if (distancetotarget.Length() < 2f) Projectile.timeLeft = 1;
		}
	}
}