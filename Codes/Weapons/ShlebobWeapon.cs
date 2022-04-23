using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using Microsoft.Xna.Framework;

namespace RatFiesta.Items.Weapons
{
    class ShlebobWeapon : ModItem
    {
		int numberProjectiles = 1;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carcass Staff");
			Tooltip.SetDefault("Summons a Carcass of past foes to fight for you.\nBoth life and death essences pour out of their bodies.\nIt reeks!");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.knockBack = -2f;
			item.mana = 10;
			item.width = 32;
			item.height = 36;
			item.useTime = 24;
			item.autoReuse = true;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item81;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<ScavengerBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<ShlebobSummon>();

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
			recipe.AddIngredient(ItemID.Gel, 15);
			recipe.AddIngredient(ItemID.Lens, 1);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}