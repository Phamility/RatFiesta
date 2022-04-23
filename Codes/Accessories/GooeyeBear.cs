
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
    class GooeyeBear : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 34;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Blue;

        }

        public override void SetStaticDefaults()
        {
          
            DisplayName.SetDefault("Slimeye's Teddy Bear");
            Tooltip.SetDefault("Provides the Calming Buff, Builder Buff and 1 defense.\nSlimeye stole this teddy bear from a boy!");

        }
     


        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.statDefense += 1;
            player.AddBuff(BuffID.Calm, 2);
            player.AddBuff(BuffID.Builder, 2);
        }
    }
}
