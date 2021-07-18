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
    class GooeyeContract : ModItem
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
            DisplayName.SetDefault("Slimeye's Contract");
            Tooltip.SetDefault("Reduces summon damage by 55%. \nIncreases max amount of minions by 2.\nIt drives you a little insane...");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.minionDamage -= .55f;
            player.maxMinions += 2;
            //Pretty self explanatory.
        }
    }
}
