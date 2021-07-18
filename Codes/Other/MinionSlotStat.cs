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
    class MinionSlotStat : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Analyzer");
			Tooltip.SetDefault("Use to display in the chat how many minions you can summon, \nminion knockback, and" +
				" your summon damage multiplier!");
		}


		public override void SetDefaults()
		{
			
			item.width = 32;

			item.height = 32;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = ItemUseStyleID.HoldingUp;
			//Like a life crystal
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Cyan;

			item.UseSound = SoundID.Item29;
			//Mana crystal sound
			item.consumable = false;
			//Makes it so it doesn't go away on use
			


		

		}
		public override bool CanUseItem(Player player)
		{
			return true;		
		}
		//Not sure if this was necessary

		public override bool UseItem(Player player)
		{
			Double X = player.minionDamage;
			Double Y = player.allDamage - 1;
			//I made these variables equaling these stats, then later rounded them to 2 decimal places
			// I -1 in all damage cause the original 100% is already there from minion damage.

			Main.NewTextMultiline("Max minions: " + player.maxMinions + "\nMinion knockback: " + player.minionKB +
				" / Summon Damage Multiplier: " + (Math.Round(X, 2) + (Math.Round(Y, 2))));
			


			return true;
		}
		
       
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID., 25);
			//This is what ud do if you want ingredients, I chose not to have any
			//recipe.AddTile(TileID.WorkBenches);
			//This is what ud do if you want any tile requirements, I chose not to have any
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
