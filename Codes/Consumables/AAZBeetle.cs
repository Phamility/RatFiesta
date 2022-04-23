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
	class AAZBeetle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Mushroom");
			Tooltip.SetDefault("When consumed, provide the Rapid Healing buff!");
		}


		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CalmingPotion);
			item.width = 32;

			item.height = 32;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.maxStack = 999;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
			item.potion = false;
			item.buffType = BuffID.RapidHealing;
			item.buffTime = 60 * 30;


		}
		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.RapidHealing, (60 * 30), false);



			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 3);
			//recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}