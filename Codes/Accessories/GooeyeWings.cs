using Terraria;
using Terraria.ModLoader;
using RatFiesta.Items.Drops;
using Terraria.ID;

namespace RatFiesta.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class GooeyeWings : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gooeye Wings");
			Tooltip.SetDefault("They're weak, but they work.");

		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 14;
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
			recipe.AddIngredient(ModContent.ItemType<Gooeye>(), 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}