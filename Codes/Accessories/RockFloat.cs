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
    class RockFloat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Orange;
            item.buffType = ModContent.BuffType<RockBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;
            //These two last lines aren't necessary, I just added them when copying and pasting some defaults.
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mineral Manipulator");
            Tooltip.SetDefault("Wearing this item summons 75 Rocks that fly around you and do 4 damage.\n" +
                "Damage is increased to 5 in expert mode.\nDamage isn't affected by buffs.\n" +
                "Deeeeefiniely not a good in single-target scenarios.");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 75);
            recipe.AddRecipeGroup(mod.Name + ":Evil", 25);
            //Reference RatFiesta -> Codes -> Other
            recipe.AddIngredient(ItemID.GravitationPotion, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            bool HasBuff = player.HasBuff(ModContent.BuffType<RockBuff>());
            if (HasBuff != true)
            {
                player.AddBuff(item.buffType, 2);
            }
//Thinking back, I think you can remove a lot and just have "player.AddBuff(item.buffType, 2);
// The 2 means 2/60 or 1/30 of a second by the way.
        }
    }
}
