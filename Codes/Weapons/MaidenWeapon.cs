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
	class MaidenWeapon : ModItem
	{

		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Shepherd's Shovel");
			Tooltip.SetDefault("This journey is long, but I will complete it.");



			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}


		public override void SetDefaults()
		{
			item.damage = 23;
			item.knockBack = 2f;
			item.melee = true;
			item.crit = 15
			;
			
			item.width = 36;
			item.autoReuse = true;
			item.height = 36;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;

			// These below are needed for a minion weapon
		

		}
		// if (Main.GameUpdateCount % 60 == 0) TIMER
		


	}
}

