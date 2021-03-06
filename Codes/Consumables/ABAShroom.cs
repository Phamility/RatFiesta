using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using RatFiesta.InRat;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;

namespace RatFiesta.Items.XConsumables
{
	class ABAShroom : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebulite Mushroom");
			Tooltip.SetDefault("When consumed, provide the Dryad's Blessing buff!");
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
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 999;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
			item.potion = false;
			item.buffType = BuffID.DryadsWard;
			item.buffTime = 60 * 30;


		}
		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(BuffID.DryadsWard, (60 * 30), false);



			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 3);
			recipe.AddTile(TileID.LunarCraftingStation);

			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}