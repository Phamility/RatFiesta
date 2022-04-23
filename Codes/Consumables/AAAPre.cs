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
	class AAAPre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pre-Workout");
			Tooltip.SetDefault("Restores 3 pla- I mean, 315 health.");
		}


		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item2;
			item.maxStack = 999;
			item.consumable = true;
			item.rare = ItemRarityID.Red;
			item.healLife = 100; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
			item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
			item.value = Item.buyPrice(gold: 10);
		}

		public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
		{
			// Make the item heal half the player's max health normally, or one fourth if used with quick heal
			healValue = 315;

		}





	}
}
