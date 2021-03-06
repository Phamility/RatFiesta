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

namespace RatFiesta.Items.XConsumables
{
	class MThreatStat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldy Analyzer");
			Tooltip.SetDefault("Use to display your current amount of idols used, and the features of them!");
		}


		public override void SetDefaults()
		{

			item.width = 32;

			item.height = 32;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.NPCDeath13;
			item.consumable = false;





		}
		public override bool CanUseItem(Player player)
		{
			return true;
		}
		
		public override bool UseItem(Player player)
		{

			Main.NewTextMultiline("You have used " + PlayerStats.Idolsconsumed + " out of 5 Mysterious Idols!\n");

			if ((PlayerStats.Idolsconsumed == 0))
			{
				Main.NewTextMultiline("You have yet to interact with the darkness...");

			}

			if (PlayerStats.Idolsconsumed >= 1)
			{
				Main.NewTextMultiline("Darkened benefits:");

			}
			if (PlayerStats1.Threat1Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Eye Of Cthulu permanently increases your max health and max mana by 30!");
			}
			if (PlayerStats2.Threat2Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from Skeletron permanently increases your defense by 6!");

			}
			if (PlayerStats.celestialconsumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Wall Of Flesh permanently increases your max number of minions by 1!");
			}
			if (PlayerStats3.Threat3Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from Plantera permanently increases your movement speed by 12%, life regeneration by 6, and mana regeneration by 6!");
			}
			if (PlayerStats4.Threat4Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Lunatic Cultist permanently increases your damage by 5%!");
			}







			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID., 25);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
