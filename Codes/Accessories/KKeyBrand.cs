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
    public class KKeyBrand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Keybrand");
            Tooltip.SetDefault("When swung, fire the projectiles of the dungeon!\nThis is what you call a real Key Brand!");
        }


        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.SnowmanCannon);
            item.damage = 122;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.width = 56;
            item.height = 30;
            item.maxStack = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            // item.useStyle = 5;
            // item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 4);
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Red;

            item.noMelee = false;
            //item.rare = ItemRarityID.Expert;
            //item.expert = true;
            item.useAmmo = AmmoID.None;
            item.shoot = ProjectileID.RocketFireworkBlue;


            //      item.shootSpeed = 4f;
            item.autoReuse = true;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                //Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                if (Main.rand.Next(1, 3) == 2)
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.LostSoulFriendly, damage, knockBack, player.whoAmI);
                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.InfernoFriendlyBolt, damage, knockBack, player.whoAmI);
                    }
                }
                else
                {
                    if (Main.rand.Next(1, 3) == 2)
                    {

                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.ShadowBeamFriendly, damage, knockBack, player.whoAmI);
                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.PaladinsHammerFriendly, damage, knockBack, player.whoAmI);
                    }

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

            recipe.AddIngredient(ItemID.Keybrand);
            recipe.AddIngredient(ModContent.ItemType<PietyFrag>());

            recipe.AddTile(TileID.LunarCraftingStation);

            //    recipe.AddTile(ModContent.TileType<RatObeliskBlock>()); //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}