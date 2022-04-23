using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using RatFiesta.Items.Drops;
using RatFiesta.Items.XConsumables;


namespace RatFiesta.Items.Accessories.EmblemSetUp.ZOther
{
	[AutoloadEquip(EquipType.Shield)]
	public class ZDarkenedSolarAegis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solar Black Aegis");

			Tooltip.SetDefault("When visible, reduce damage taken by 8%!\nWhen hidden, reduce damage taken by -10% to 25%. This value changes sporadically.!\nIncreases melee damage by 10%.\nGrants immunity to knockback and fire blocks.\nGrants immunity to most debuffs.\n" +
				"An indescribale message from A Mysterious Force can be heard in your head.\nThe message gives you the thoughts of 'Quite' 'Impressive' 'Adventure' and 'Beyond'");
		   //     "The message gives you the thoughts of 'Interesting' Invintation' 'Journey' and 'More'"");
		}
		//"When visible, increase summon damage by 90%!\nWhen hidden, decrease max amount of minions by 4 and increase summon damage by 180%!\nA measly piece of the Dark Continent achieved greater feats then this realm could ever imagine.\nAn indescribale message from A Mysterious Force can be heard in your head when equipped.\n" +
		//     "The message gives you the thoughts of 'Interesting' Invintation' 'Journey' and 'More'"
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 34;
			item.value = Item.sellPrice(platinum: 12);
			item.accessory = true;
			item.rare = ItemRarityID.Expert;
			item.expert = true;

		}
		public int RandomAF;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamageMult += .1f;

			if (Main.rand.Next(1, 9) == 2)
			{
				if (Main.rand.Next(1, 3) == 2)
				{
					RandomAF = (Main.rand.Next(1, 11) * -1);

				}
				else
				{
					
						RandomAF = Main.rand.Next(1, 26);

					
				
				}
			}
			if (hideVisual == true)
			{
				player.endurance += RandomAF * .01f;


			}
			else
			{
				player.endurance += .08f;
			}
			player.buffImmune[22] = true;
			player.buffImmune[31] = true;
			player.buffImmune[30] = true;
			player.noKnockback = true;
			player.buffImmune[32] = true;

			player.buffImmune[20] = true; player.buffImmune[80] = true;

			player.buffImmune[24] = true;
			player.buffImmune[33] = true;


			player.buffImmune[35] = true;

			player.buffImmune[36] = true;

			player.buffImmune[46] = true;

			player.buffImmune[67] = true;

			player.buffImmune[23] = true;

			player.buffImmune[69] = true;

			player.buffImmune[70] = true;

			player.buffImmune[39] = true;




		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LunaticAegis>());
			recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
			recipe.AddIngredient(ItemID.LunarBar, 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}