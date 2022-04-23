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
    class BossBag : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open!");

        }
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 32;
            item.maxStack = 999;
            item.rare = ItemRarityID.Expert;

            item.expert = true;
            item.consumable = true;
        }
        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.GoldCoin, 5);
            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("HeartOfRe"), 1, true, -1);

            Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("Gooeye"), Main.rand.Next(14, 23), true, -1);

            player.QuickSpawnItem(ModContent.ItemType<ABenGay>(), Main.rand.Next(10,15));
            //ADD GEL ARMORISH COMPOENNT SHT TMRW, CHECK BOSS

        if(Main.rand.Next(1,6) == 2)
            {
                if (Main.rand.Next(1, 4) == 2)
                {
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeBear"), 1, true, -1);
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeExchange"), 1, true, -1);

                }
                else if (Main.rand.Next(1, 3) == 2)
                {
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeBear"), 1, true, -1);
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeContract"), 1, true, -1);

                }
                else
                {
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeContract"), 1, true, -1);
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeExchange"), 1, true, -1);

                }





            }
            else

            if(Main.rand.Next(1,4) == 2)
            {
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeBear"), 1, true, -1);

            } else if (Main.rand.Next(1,3) == 2)
            {
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeContract"), 1, true, -1);

            }
            else
            {
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("GooeyeExchange"), 1, true, -1);

            }
        }
        public override int BossBagNPC => ModContent.NPCType<Slimeye>();
    }
}