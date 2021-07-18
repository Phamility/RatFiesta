
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Weapons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
namespace RatFiesta.Mods
{
    class ExamplePlayer : ModPlayer
    {
		
        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ModContent.ItemType<MinionSlotStat>());
			item.stack = 1;
			items.Add(item);
			Item item3 = new Item();
			item3.SetDefaults(ModContent.ItemType<MThreatStat>());
			item3.stack = 1;
			items.Add(item3);
			Item item2 = new Item();
			item2.SetDefaults(ModContent.ItemType<RatWandWeapon>());
			item2.stack = 1;
			items.Add(item2);
			Item item4 = new Item();
			item4.SetDefaults(ItemID.WoodenBow);
			item4.stack = 1;
			items.Add(item4);
			Item item5 = new Item();
			item5.SetDefaults(ItemID.WoodenArrow );
			item5.stack = 299;
			items.Add(item5);
			Item item6 = new Item();
			item6.SetDefaults(ModContent.ItemType<ABossSummon>());
			item6.stack = 2;
			items.Add(item6);

		}
	
	}
}
