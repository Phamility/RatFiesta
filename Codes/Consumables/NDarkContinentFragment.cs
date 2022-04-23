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

namespace RatFiesta.Items.XConsumables
{
    class NDarkContinentFragment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Continent Fragment");
            Tooltip.SetDefault("A fragment of the Moon Lord's hometown came from it's core.");
        }
		public override void SetDefaults()
		{

			item.width = 32;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 4));

			item.height = 32;
			
			ItemID.Sets.ItemNoGravity[item.type] = true;
			item.value = Item.buyPrice(10, 0, 0, 0);
			item.rare = ItemRarityID.Expert;
			item.expert = true;


		}

		}

	/*int frameSpeed = 3;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}*/
	}

