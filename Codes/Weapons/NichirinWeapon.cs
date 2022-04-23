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
	class NichirinWeapon : ModItem
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nichirin Sword");
			Tooltip.SetDefault("It's black. \nSomehow it sets enemies on fire!");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}


		public override void SetDefaults()
		{
			item.damage = 7;
			item.knockBack = 2f;
			item.melee = true;
			item.crit = 5
			;

			item.width = 34;
			item.autoReuse = true;
			item.height = 34;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;

			// These below are needed for a minion weapon


		}
		// if (Main.GameUpdateCount % 60 == 0) TIMER
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.anyIronBar = true;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}



	}
}



