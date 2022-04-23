using System;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;

using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;
using RatFiesta.Items.Drops;
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Accessories.TGlass;


namespace RatFiesta.Items.Accessories.EmblemSetUp.ZOther

{
    public class KTrueKeyBrand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartless Keybrand");
            Tooltip.SetDefault("When swung, fire varying projectiles - like, really varying!\nDearly Beloved. I'm Sorry.");
        }

 
        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.SnowmanCannon);
            item.damage = 273;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.width = 56;
            item.height = 30;
            item.maxStack = 1;
            item.useTime = 10;
            item.useAnimation = 10;
            // item.useStyle = 5;
            // item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 12);
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Expert;

            item.noMelee = false;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            item.useAmmo = AmmoID.None;
            item.shoot = ProjectileID.RocketFireworkBlue;


            //      item.shootSpeed = 4f;
            item.autoReuse = true;
        }
      

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            


            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.

                if (Main.rand.Next(1, 50) == 2) { 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.RocketFireworkGreen, damage, knockBack, player.whoAmI);
            }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GreenLaser, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.LightBeam, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.NightBeam, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.EnchantedBeam, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalLeafShot, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.IceSickle, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.BoulderStaffOfEarth, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.BallofFrost, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.DeathSickle, damage, knockBack, player.whoAmI);
                }
                //-------------
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.LostSoulFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PaladinsHammerFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.InfernoFriendlyBolt, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GoldenShowerFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.VampireKnife, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.FlamingJack, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Blizzard, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.RocketSnowmanI, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PineNeedleFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ImpFireball, damage, knockBack, player.whoAmI);
                }
                //-------------
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MiniRetinaLaser, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MiniSharkron, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Typhoon , damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Bubble, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Meteor1, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.InfluxWaver, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.StarWrath, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Meowmere, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.NebulaBlaze1, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.TerraBeam, damage, knockBack, player.whoAmI);
                }
                //-------------
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.EighthNote, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.DemonScythe, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.EatersBite, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ShadowBeamFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.BallofFire, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MagnetSphereBall, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Bullet, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.EnchantedBoomerang, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.RainbowCrystalExplosion, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.SpiritFlame, damage, knockBack, player.whoAmI);
                }
                //-------------
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.SkyFracture, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.BlackBolt, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ClothiersCurse, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.DryadsWardCircle, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MagicDagger, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ShadowFlameKnife, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.IchorDart, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Xenopopper, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ElectrosphereMissile, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.ChlorophyteOrb, damage, knockBack, player.whoAmI);
                }
                //-------------
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MagicDagger, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CursedFlameFriendly, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.LightDisc, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PossessedHatchet, damage, knockBack, player.whoAmI);
                }
                if (Main.rand.Next(1, 50) == 2)
                {
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.Beenade, damage, knockBack, player.whoAmI);
                }




                // If you want to randomize the speed to stagger the projectiles
                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                // perturbedSpeed = perturbedSpeed * scale; 
            }
            return false; // return false because we don't want tmodloader to shoot projectile
                          // return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<KKeyBrand>());
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddIngredient(ItemID.FragmentSolar, 4);

            recipe.AddTile(TileID.LunarCraftingStation);

            //    recipe.AddTile(ModContent.TileType<RatObeliskBlock>()); //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}