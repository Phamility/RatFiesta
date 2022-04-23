
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
    class StonedirwoodWeapon : ModItem
    {
		int numberProjectiles = 1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stonedirwood Staff");
			Tooltip.SetDefault("Summons a Stonedirwood to fight for you.\nA staff made of stone, dirt, and wood that\nsummons a Stonedirwood made out of stone, dirt, and wood. ");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.knockBack = -2f;
			item.autoReuse = true;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item79;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<EarthBenderBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<StonedirwoodSummon>();

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
			recipe.AddIngredient(ItemID.Wood, 50);
			recipe.anyWood = true;
				recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddIngredient(ItemID.DirtBlock, 25);


			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}
