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
    class QDRing : ModItem
    {


        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Green;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacial Shroom Ring");
            Tooltip.SetDefault("When visible, increase life regeneration by 2.\nWhen hidden, increase life regeneration by 8 but reduce movement speed by 35%\nProvides the Lamp Heart buff.\nYou feel a little chilly!");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(BuffID.HeartLamp, 2);
            if (showVisual == true)
            {
                player.lifeRegen += 8;
                player.runAcceleration *= .65f;
                player.maxRunSpeed *= .65f;

            }
            else
            {
                player.lifeRegen += 2;

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AAIAFreeze>(), 3);
       //     recipe.AddIngredient(ItemID.Mushroom, 25);

            // recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}