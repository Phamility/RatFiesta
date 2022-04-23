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
using Terraria.DataStructures;
using System.Threading.Tasks;

namespace RatFiesta.Items.Accessories.Infinity
{
	class AKeyStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unbranded Keystone");
			Tooltip.SetDefault("The choice is yours.");
		}
		public override void SetDefaults()
		{
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));

			item.width = 42;

			item.height = 42;
			item.maxStack = 1;

			item.value = Item.buyPrice(0, 0, 0, 0);
			item.rare = ItemRarityID.White;


		}

	}
}
