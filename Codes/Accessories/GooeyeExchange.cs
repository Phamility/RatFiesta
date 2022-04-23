using Microsoft.Xna.Framework;
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

namespace RatFiesta.Items.Accessories
{
    class GooeyeExchange : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Blue;

        }

        public override void SetStaticDefaults()
        { 
            DisplayName.SetDefault("Slimeye's Law of EquivalentExchange");
            Tooltip.SetDefault("Reduces minion slots by 2. \nIncreases damage by 18%.\nFMA...FMA...");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += .18f;
            player.maxMinions -= 2;
        }


    }

}
