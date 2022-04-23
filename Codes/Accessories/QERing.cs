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
    class QERing : ModItem
    {


        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.Orange;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Honey Glazed Shroom Ring");
            Tooltip.SetDefault("When visible, increase life regeneration by 6.\nWhen hidden, increase life regeneration by 23 but reduce movement speed by 55%\nProvides the Honey buff.\nYou feel sticky and sluggish!");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(BuffID.Honey, 2);
            if (showVisual == true)
            {
                player.lifeRegen += 23;
                player.runAcceleration *= .45f;
                player.maxRunSpeed *= .45f;

            }
            else
            {
                player.lifeRegen += 6;

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AAIAHoney>(), 3);
            //     recipe.AddIngredient(ItemID.Mushroom, 25);

            // recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}