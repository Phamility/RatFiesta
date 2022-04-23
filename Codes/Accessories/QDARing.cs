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
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories
{
    class QDARing : ModItem
    {


        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Ring");
            Tooltip.SetDefault("When visible, increase life regeneration by 1.\nWhen hidden, increase life regeneration by 4 but reduce movement speed by 15%\nProvides the Campfire buff.");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(BuffID.Campfire, 2);
            if (showVisual == true)
            {
                player.lifeRegen += 4;
                player.runAcceleration *= .85f;
                player.maxRunSpeed *= .85f;

            }
            else
            {
                player.lifeRegen += 1;

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // recipe.AddIngredient(ModContent.ItemType<AAIAFreeze>(), 25);
            recipe.AddIngredient(ItemID.Mushroom, 3);

            // recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}