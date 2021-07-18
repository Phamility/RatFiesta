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

namespace RatFiesta.Items.Accessories.EmblemSetUp
{
    class TrueDarkDustedEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 20);
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            //The second to last line makes it so that the item appears a rainbow color, the last line makes it so it doesn't change color when reforged.
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Darkdusted Emblem");
            Tooltip.SetDefault("When visible, increase summon damage by 90%!\nWhen hidden, decrease max amount of minions by 4 and increase summon damage by 180%!\nA measly piece of the Dark Continent achieved greater feats then this realm could ever imagine.\nAn indescribale message from A Mysterious Force can be heard in your head when equipped.\n" +
                "The message gives you the thoughts of 'Interesting' Invintation' 'Journey' and 'More'");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            if (showVisual == true)
            //This means that if the icon right of the accessory is greyd out, or NOT visible, this results true and you lose 4 minion slots, though you gain 180% minions damage
            {
                player.minionDamage += 1.8f;
                player.maxMinions -= 4;
                
            }
            else
            //If it IS visible, no minion slots are loss and +90% damage is gained.
            //Unrelated to code, but wish more sacrifical concepts like these exist, though the problem here is you can some Max minions - 4 with boosted damage, then make it visible
                //and put out 4 slightly boosted minions, but whateeeeeever.
            {
                player.minionDamage += .9f;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TrueSundustedEmblem>());
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
         //Previous 2 lines reference modded content, if you wanted vanilla items as ingredients, use "(ItemID."ThatItemsName)", ofc without the quotes. 
            recipe.AddTile(TileID.LunarCraftingStation);
            //Makes it so it requires the Ancient Manipulator, yes it's called Lunar Crafting Station in code.
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
