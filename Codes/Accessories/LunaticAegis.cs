using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using RatFiesta.Items.Drops;

namespace RatFiesta.Items.Accessories.EmblemSetUp.ZOther
{
	[AutoloadEquip(EquipType.Shield)]
	public class LunaticAegis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunatic Aegis");

			Tooltip.SetDefault("Provides 5 to 15 defense. This value changes randomly.\nGrants immunity to knockback and fire blocks.\nGrants immunity to most debuffs.");
		}

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 34;
			item.value = Item.sellPrice(platinum: 4);
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		//	item.expert = false;


		}
		public int RandomAF;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{

			if (Main.rand.Next(1, 17) == 2)
			{
				if (Main.rand.Next(1, 4) == 2)
				{
					RandomAF = Main.rand.Next(11, 16);

				}
				else
				{
					RandomAF = Main.rand.Next(5, 12);
				}
			}
			player.statDefense += RandomAF;
			player.buffImmune[22] = true;
			player.buffImmune[31] = true;
			player.buffImmune[30] = true;

			player.buffImmune[32] = true;

			player.buffImmune[20] = true;

			player.buffImmune[24] = true;
			player.buffImmune[33] = true;

			player.noKnockback = true;

			player.buffImmune[35] = true;

			player.buffImmune[36] = true;

			player.buffImmune[46] = true;

			player.buffImmune[67] = true;

			player.buffImmune[23] = true;

			player.buffImmune[69] = true;

			player.buffImmune[70] = true;

			player.buffImmune[39] = true;
			player.buffImmune[80] = true;



		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AnkhShield);

			recipe.AddIngredient(ModContent.ItemType<PietyFrag>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}