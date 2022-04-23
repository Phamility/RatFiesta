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
    class RBRing : ModItem
    {


        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Yellow;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reinforced Shell Shroom Ring");
            Tooltip.SetDefault("When visible, increase life regeneration by 11.\nWhen hidden, increase life regeneration by 44 but reduce movement speed by 85%\nProvides the Rapid Healing buff.\nYou feel like a rock.");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(BuffID.RapidHealing, 2);
            if (showVisual == true)
            {
                if (player.GetModPlayer<ExamplePlayer>().RatRingOn == false)
                {
                    player.lifeRegen += 44;
                }
                player.runAcceleration *= .15f;
                player.maxRunSpeed *= .15f;

            }
            else
            {
                player.lifeRegen += 11;

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AAZBeetle>(), 3);
            //     recipe.AddIngredient(ItemID.Mushroom, 25);

          // recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}