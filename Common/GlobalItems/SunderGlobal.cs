
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Runic.Content.Imbues;
using Runic.Common.Players;
using Runic.Content.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Runic.Content.Damageclass;


//using Runic.Common.Players;

namespace Runic.Common.GlobalItems
{
    // use this as a template for all imbues


    public class Sunder : GlobalItem
    {



        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod);


            if (item.shoot == ProjectileID.None)


            {
                // add a projectile that does noting so adding a new seprate effect works and doesnt fuck with things that already have one

                item.shoot = ModContent.ProjectileType<DummyProj>();




            }



        }

        public override void ModifyShootStats(Item item, Terraria.Player player, ref Vector2 position, ref Vector2 velocity, ref System.Int32 type, ref System.Int32 damage, ref System.Single knockback)
        {
            if (item.prefix == ModContent.PrefixType<Sundering>())
            {
                var modPlayer = Main.LocalPlayer.GetModPlayer<ResourceSoul>();
                int NewProjType = ModContent.ProjectileType<ChillProj>();
                int totalshield = 4;
                int ProjectileDamage = (int)(3 + (player.GetDamage<RunicDamage>().ApplyTo(1)/.2f));
                float ProjectileKnockBack = 4 + player.GetDamage<RunicDamage>().ApplyTo(3);
                Vector2 ProjectileVelocity = Vector2.UnitX * 6.5f;
                SoundStyle NewSound = new SoundStyle("Runic/Assets/Sounds/Chill_Shot");
                if (player.altFunctionUse == 2 && modPlayer.SoulCurrent >= 15)
                {
                    modPlayer.SoulCurrent = modPlayer.SoulCurrent - 15;
                    {
                        int numprojs = 0;
                        while (numprojs < totalshield) 
                        {
                            numprojs++;
                            Vector2 TileTry = Vector2.Zero;
                            TileTry.X += (Vector2.UnitX.RotatedByRandom(Math.PI)).X;
                            TileTry.Y += (Vector2.UnitX.RotatedByRandom(Math.PI)).Y;
                            TileTry *= 320;
                            int j = 0;
                            while (!OkayTileSpot(player.position + TileTry) && j < 200) //Find a legal spot to rip a tile from
                            {
                                j++;
                                TileTry = Vector2.Zero;
                                TileTry.X += (Vector2.UnitX.RotatedByRandom(Math.PI)).X;
                                TileTry.Y += (Vector2.UnitX.RotatedByRandom(Math.PI)).Y;
                                TileTry *= 320;
                            }
                            if (j < 200) //If we find a viable spot, spawn the tile.
                            {

                                int newproj = Projectile.NewProjectile(item.GetSource_FromThis(), player.position + TileTry, ProjectileVelocity,
                            ModContent.ProjectileType<ThrownTile>(), ProjectileDamage, ProjectileKnockBack, player.whoAmI);
                                Projectile tileproj = Main.projectile[newproj];
                                tileproj.penetrate = 30;
                                tileproj.timeLeft = 1800;
                                int ProjID = Projectile.NewProjectile(item.GetSource_FromThis(), player.position + TileTry, ProjectileVelocity, 
                                    ModContent.ProjectileType<LightningArcVisual>(), 0, ProjectileKnockBack, player.whoAmI);
                                Projectile proj = Main.projectile[ProjID];
                                proj.ai[0] = player.Center.X;
                                proj.ai[1] = player.Center.Y;
                                proj.scale = 1.1f;
                                if (Main.netMode == NetmodeID.MultiplayerClient && Main.myPlayer == proj.owner)
                                {
                                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, newproj);
                                }
                            }
                        }
                        Projectile.NewProjectile(item.GetSource_FromThis(), position, velocity, NewProjType, damage, knockback, player.whoAmI);
                        SoundEngine.PlaySound(NewSound);
                    }
                }
            }
        }




        public override bool AltFunctionUse(Item item, Terraria.Player player)
        {
            if (item.prefix == ModContent.PrefixType<Sundering>()) //makes sure non special prefixed items dont have an alt use 
            {

                return true;
            }

            return false;
        }
        public bool OkayTileSpot(Vector2 position)
        {
            Vector2 tilelocation = Vector2.Zero;
            tilelocation.X = (int)(position.X / 16);
            tilelocation.Y = (int)(position.Y / 16);
            Tile targetile = Main.tile[(int)tilelocation.X, (int)tilelocation.Y];
            if (targetile.HasTile)
            {
                Item ItemChosen = null;
                for (int i = 0; i < ItemLoader.ItemCount; i++)
                {
                    if (ContentSamples.ItemsByType[i].createTile == targetile.TileType && ContentSamples.ItemsByType[i].consumable == true)
                    {
                        ItemChosen = ContentSamples.ItemsByType[i];
                        break;
                    }
                }
                if (ItemChosen == null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }




    }


}
