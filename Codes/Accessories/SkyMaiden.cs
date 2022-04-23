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
    class SkyMaiden : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Green;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Maiden's Blessing");
            Tooltip.SetDefault("Increase defense by 1\nReduce damage taken by 2%%\nIncreases damage by 3%\nIncrease movement speed by 4%\nThe sky's the limit! ");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 1;
            player.endurance += .02f;
            player.allDamage += .03f;
            player.runAcceleration *= 1.04f;
            player.maxRunSpeed *= 1.04f;


        }


    }

}
