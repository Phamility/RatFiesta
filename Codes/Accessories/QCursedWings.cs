using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using RatFiesta.Items.Drops;
using Terraria.DataStructures;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;



using Terraria.ID;
using Terraria.Utilities;
using System.Threading.Tasks;
using RatFiesta.Mods;

using System.Linq;
using Terraria.ModLoader.IO;


namespace RatFiesta.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class QCursedWings : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ghost Wings");
			Tooltip.SetDefault("With evil and with undead, our tracks are now sealed.");

		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 100000;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 40;
	//		Main.NewTextMultiline("" + player.GetModPlayer<ExamplePlayer>().Endurance);

		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.65f;
			ascentWhenRising = 0.10f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.75f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 8f;
			acceleration *= 1.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.Cloud, 20);
			recipe.AddRecipeGroup(mod.Name + ":EvilFlesh", 10);
			
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}