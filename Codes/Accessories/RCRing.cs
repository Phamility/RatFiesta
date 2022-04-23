using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using RatFiesta.Mods;
using System.Linq;
using RatFiesta.Mods;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories
{
    class RCRing : ModItem
    {


        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 40);
            item.rare = ItemRarityID.Red;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Infused Shroom Ring");
            Tooltip.SetDefault("When visible, increase life regeneration by 16.\nWhen hidden, increase life regeneration by 62 but reduce movement speed by 95%\nProvides the Dryad's Blessing buff.\nThis power lessens your movement!");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(BuffID.DryadsWard, 2);
            if (showVisual == true)
            {
                if (player.GetModPlayer<ExamplePlayer>().RatRingOn == false)
                {
                    player.lifeRegen += 62;
                }
                player.runAcceleration *= .05f;
                player.maxRunSpeed *= .05f;

            }
            else
            {
                player.lifeRegen += 16;

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ABAShroom>(), 3);
            //     recipe.AddIngredient(ItemID.Mushroom, 25);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}