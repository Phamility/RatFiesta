
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
namespace RatFiesta.Items.XConsumables
{
    class OStinky : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Gray;
            item.UseSound = SoundID.Item16;
        }

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Stinky's Stinky");
            Tooltip.SetDefault("Haha. Poop.");

        }



        public override void UpdateAccessory(Player player, bool showVisual)
        {

            player.AddBuff(BuffID.Stinky, 2);

        }

        public override void UpdateVanity(Player player, EquipType type)
        {
            player.AddBuff(BuffID.Stinky, 2);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
