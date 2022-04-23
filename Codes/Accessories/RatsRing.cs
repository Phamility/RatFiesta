using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;
using Terraria;
using System.IO;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using RatFiesta.Mods;
using System.Text;
using System.Threading.Tasks;

namespace RatFiesta.Items.Accessories
{
    class RatsRing : ModItem
    {
      
        
        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(copper: 1);
            item.rare = ItemRarityID.Lime;
            

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rat's Ring");
            Tooltip.SetDefault("Increases damage by 200% but drains life rapidly - like, really rapidly..\nYour feeble body can't handle this power.\nOnly a true rat can wield this power!\nCaptain Omeet on duty!");

        }
        public float FinalBooga;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.GetModPlayer<ExamplePlayer>().RatRingOn = true;
           
                player.allDamage += 2f;

            if (player.GetModPlayer<ExamplePlayer>().RatWorn > 0)
            {
                if (Main.expertMode == true) { FinalBooga = player.GetModPlayer<ExamplePlayer>().RatWorn + (player.statDefense / (1 / .75f)); }
                else if (Main.expertMode == false) { FinalBooga = player.GetModPlayer<ExamplePlayer>().RatWorn + (player.statDefense / (1 / .5f)); }
                if (player.lifeRegen >= 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.Hurt(PlayerDeathReason.ByCustomReason("The power of the rat was too much for " + player.name), (int)Math.Round(FinalBooga), 0);
                player.immune = false;
                player.immuneTime = 0;
                player.lifeRegen = 0;
               
             //   player.lifeRegen -= player.GetModPlayer<ExamplePlayer>().RatWorn;

            }
            
        }
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AAShroom>(), 3);

            // recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}