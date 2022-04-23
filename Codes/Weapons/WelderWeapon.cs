
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;

namespace RatFiesta.Items.Weapons
{
	class WelderWeapon : ModItem
	{
		int numberProjectiles = 1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mineral Staff");
			Tooltip.SetDefault("Summons a Garbore to fight for you.\nWe're not sure how it got some of it's colors.\nIt doesn't have eyes so it senses the iron \nin living creatures to find it's prey!");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 36;
			item.knockBack = -2f;
			item.autoReuse = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item77;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<WelderBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<GarboreSummon>();

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{


			{
				for (int i = 0; i < numberProjectiles; i++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer);
				}
				// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			}
			player.AddBuff(item.buffType, 2);


			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddRecipeGroup(mod.Name + ":CobaltPaladium", 10);
			recipe.AddRecipeGroup(mod.Name + ":OriMythril",10);
			recipe.AddRecipeGroup(mod.Name + ":AdaTit", 10);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
		
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}