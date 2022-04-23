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
    class ABossSummon : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ominous Looking Geli");
            Tooltip.SetDefault("Summons Slimeye!");
        
        }
        public override void SetDefaults()
        {
           
            item.width = 30;
            item.height = 20;
            item.maxStack = 20;
            item.rare = ItemRarityID.White;
            item.useAnimation = 45;
            
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
           // item.UseSound = SoundID.;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (NPC.AnyNPCs(mod.NPCType("Slimeye")))
            {
                return false;
            }
            else
            {
                if (Main.dayTime == false)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Slimeye"));
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddIngredient(ItemID.Lens, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
