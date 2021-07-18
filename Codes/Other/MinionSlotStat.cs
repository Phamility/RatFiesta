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
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Cyan;

			item.UseSound = SoundID.Item29;
			item.consumable = false;
			


		

		}
		public override bool CanUseItem(Player player)
		{
			return true;		
		}

		public override bool UseItem(Player player)
		{
			Double X = player.minionDamage;
			Double Y = player.allDamage - 1;

			Main.NewTextMultiline("Max minions: " + player.maxMinions + "\nMinion knockback: " + player.minionKB +
				" / Summon Damage Multiplier: " + (Math.Round(X, 2) + (Math.Round(Y, 2))));
			

			






			return true;
		}
		
       
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID., 25);
			//recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
