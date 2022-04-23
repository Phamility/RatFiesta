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
    class ZGolemsContract : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Lime;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golem's Contract");
            Tooltip.SetDefault("Reduces summon damage by 60%. \nIncreases max amount of minions by 6.\nThis great army comes at a great cost!");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage -= .6f;
            player.maxMinions += 6;
        }


    }

}
