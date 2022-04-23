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
	class AAShroom : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omeet's Shroom");
			Tooltip.SetDefault("Dude. I don't think you should-");
		}


		public override void SetDefaults()
		{

			item.width = 32;

			item.height = 32;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.maxStack = 999;
			item.UseSound = SoundID.Item2;
			item.consumable = true;





		}
		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.Poisoned, (60 * 30), true);
			player.statLife -= 20;
			










			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 1);
			recipe.AddIngredient(ItemID.VialofVenom, 3);
			//recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
