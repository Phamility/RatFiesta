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
	//Fun fact, I tried to make this a buff, but ModifyBuffTip was so WACK to use, so i made it display in the chat
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
			//wof noises
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
			//Anytime u consume an idol, it creases the number, if u consumed 0 or 1+, it shows above or below

			if (PlayerStats.Idolsconsumed >= 1)
			{
				Main.NewTextMultiline("Darkened benefits:");

			}
			//I put them in order at which u get them
			//I made a bunch of things similar to PlayerStats2, not sure how to do it combined so I hard coded it.
				//Reference Rat Fiesta -> Codes -> Other
			if (PlayerStats1.Threat1Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Eye Of Cthulu permanently increases your max health and max mana by 30!");
			}
			if (PlayerStats2.Threat2Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from Skeletron permanently increases your defense by 8!");

			}
			if (PlayerStats.celestialconsumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Wall Of Flesh permanently increases your max number of minions by 1!");
			}
			if (PlayerStats3.Threat3Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from Plantera permanently increases your movement speed by 15% and life regeneration by 10!");
			}
			if (PlayerStats4.Threat4Consumed == true)
			{
				Main.NewTextMultiline("The Mysterious Idol from the Lunatic Cultist permanently increases your damage by 12%!");
			}







			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//No ingredients
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
