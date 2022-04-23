using System;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Minions.Reality;
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

namespace RatFiesta.Items.Weapons
{
    public class NebulaStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Beam Staff");
            Tooltip.SetDefault("Conjures a massive laser.\nVVVVVVVVVV.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.ShadowbeamStaff);
            recipe.AddIngredient(ModContent.ItemType<PietyFrag>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
        {

            item.damage = 672;
            item.magic = true;
            item.width = 70;
            item.mana = 230;
            item.height = 28;
            item.maxStack = 1;
            item.useTime = 150;
            item.useAnimation = 150;
            item.useStyle = 1;
            item.knockBack = 1.5f;
            item.value = Item.sellPrice(platinum: 4);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item117;
            item.noMelee = true;
            //      item.shootSpeed = 4f;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<RSummon17>();
           
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
  Projectile.NewProjectile(player.position.X - 1500, player.position.Y, 0f, 0f, ModContent.ProjectileType<RSummon17>(), damage, 1.5f, player.whoAmI);
            return false;

        }
    }
}


//						Projectile.NewProjectile(player.position.X - 300, player.position.Y, 0f, 0f, ModContent.ProjectileType<RSummon16>(), 9999, -5f, Main.myPlayer);
