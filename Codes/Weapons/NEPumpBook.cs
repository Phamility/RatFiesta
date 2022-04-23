using System;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Minions.Reality;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;
using RatFiesta.InRat;
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
namespace RatFiesta.Items.Weapons
{
    public class NEPumpBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmos' Halloween");
            Tooltip.SetDefault("Summons a bunch of Jack O' Lanterns from the sky!\nHalloween!");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.SpellTome);
            recipe.AddIngredient(ModContent.ItemType<RatEssence>(), 99);

            recipe.AddIngredient(ItemID.ExplosiveJackOLantern, 99);

            recipe.AddTile(ModContent.TileType<RatObeliskBlock>()); //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {

            item.damage = 198;
            item.magic = true;
            item.width = 30;
            item.mana = 30;
            item.height = 28;
            item.maxStack = 1;

            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;

            item.knockBack = 10f;
            item.value = Item.sellPrice(platinum: 20);
            item.rare = ItemRarityID.Purple;
         //   item.expert = true;

            item.UseSound = SoundID.Item8;
            item.noMelee = true;
            //      item.shootSpeed = 4f;
            item.autoReuse = true;
            item.shoot = ProjectileID.JackOLantern;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 9;
            for (int i = 0; i < numberProjectiles; i++)
            {

                Projectile.NewProjectile(Main.MouseWorld.X + ( Main.rand.Next(0, 30 ) - 15), player.position.Y - 350, (Main.rand.Next(0, 6) - 3), 0f, type, damage, 10f, player.whoAmI);

        }
                return false;

        }
    }
}