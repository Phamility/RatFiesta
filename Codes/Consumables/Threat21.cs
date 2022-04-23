using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;

namespace RatFiesta.Items.XConsumables
{
	internal class Threat21 : ModItem
	{
		

		public override void SetStaticDefaults()
		{


			DisplayName.SetDefault("Mysterious Idol");
			Tooltip.SetDefault("Permanently increases your max amount of minions by 1! \nCan only be used once.\nA faint sound can be heard, 'Ai...'");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LifeFruit);
			item.width = 36;
			item.maxStack = 99;
			item.height = 36;
		//	Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(60, 2));
			
			item.consumable = true;
			item.UseSound = SoundID.NPCDeath13;
			item.value = Item.sellPrice(gold: 20);
			item.rare = ItemRarityID.White;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<PlayerStats>().usedCelestial3Consumption < PlayerStats.maxCelestial3Consumption;
		}

		public override bool UseItem(Player player)
		{
			//Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(60, 2));
			//	player.maxMinions += 1;

			player.GetModPlayer<PlayerStats>().usedCelestial3Consumption += 1;
			return true;
		}
	}
}