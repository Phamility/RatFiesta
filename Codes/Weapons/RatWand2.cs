
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using RatFiesta.Items.Weapons;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;

using System.Threading.Tasks;

namespace RatFiesta.InRat
{
	class RatWand2 : ModItem
	{

		int numberProjectiles = 1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Rat Staff");
			Tooltip.SetDefault("Summons an Otherworldly Rat to fight for you.\nEach rat takes up 4 minion slots!\nFresh off the unkno wn!");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.damage = 2022;
			item.knockBack = -3f;
			item.mana = 80;
			item.width = 32;
			item.height = 32;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item83;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<RatKingBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<RatSummon2>();

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
			recipe.AddIngredient(ModContent.ItemType<RatWandWeapon>());
			recipe.AddIngredient(ModContent.ItemType<RatEssence>(), 44);

			//recipe.AddIngredient(ItemID., 25);
			recipe.AddTile(ModContent.TileType<RatObeliskBlock>()); //at work bench
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

