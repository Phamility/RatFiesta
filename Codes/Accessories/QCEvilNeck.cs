
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
    class QCEvilNeck : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            ItemID.Sets.ItemNoGravity[item.type] = true;

            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Green;

        }

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Defiled Necklace");
            Tooltip.SetDefault("Provides 7% damage\nWhen hidden, provide an extra 18% melee attack speed but decrease max mana by 100");

        }



        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            if (hideVisual == true)
            {
                player.allDamage += .07f;
                player.meleeSpeed += .18f;
                player.statManaMax2 -= 100;

            }
            else
            {
                player.allDamage += .07f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(mod.Name + ":EvilBar", 7);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
