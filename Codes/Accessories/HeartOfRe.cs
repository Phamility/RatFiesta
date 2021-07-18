using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories
{
    class HeartOfRe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            //The first of the last two lines makes the item rainbow color, the other makes it so it's color can't be changed through reforging.

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Of Resilience");
            Tooltip.SetDefault("Provides 5 life regeneration, 3 defense, and 3% movement speed. \nThese stats are doubled when below 70% health, \ndoubled again when below 35% health, \nand doubled one more time when below 10% health.");
            //Incase you didn't know, "\n" pushes the line in the tooltip down a line.

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
        //The lowest percentage of health, 10%, is putten first because it is fulfilled by less than 35% and 70%, so if it were to be put at the end,
        //it would never go through, so always in a case like this, go from smallesrt to largest.
            if (player.statLife <= (player.statLifeMax2 * .1f))
            {
                player.runAcceleration *= 1.24f;
                player.maxRunSpeed *= 1.24f;
                player.lifeRegen += 40;
                player.statDefense += 24;
            }
            else if (player.statLife <= (player.statLifeMax2 * .35f))
            {
                player.runAcceleration *= 1.12f;
                player.maxRunSpeed *= 1.12f;
                player.lifeRegen += 20;
                player.statDefense += 12;
            }
            else if (player.statLife <= (player.statLifeMax2 * .70f))
            {
                player.runAcceleration *= 1.06f;
                player.maxRunSpeed *= 1.06f;
                player.lifeRegen += 10;
                player.statDefense += 6;
            }
            else
            {
                player.runAcceleration *= 1.03f;
                player.maxRunSpeed *= 1.03f;
                player.lifeRegen += 5;
                player.statDefense += 3;
            }

        }
    }
}
