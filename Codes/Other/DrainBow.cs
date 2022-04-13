using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;

using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;
using RatFiesta.Items.Drops;

namespace RatFiesta.Items.Weapons

{
    public class DrainBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gooeye Bow");
            Tooltip.SetDefault("Costs 4 Health for each arrow!\nThis bow is disgusting to use.");
        }

        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.WoodenBow);
            item.damage = 30;
            item.ranged = true;
            item.width = 12;
            item.height = 40;
            item.maxStack = 1;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item102;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo =  AmmoID.Arrow;
            item.shootSpeed = 4f;
            item.autoReuse = true;
        }
        public float InsertDamage = 4.4f;
        public float OogaBooga;
        public float FinalBooga;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            InsertDamage = 4.4f;

            if (Main.expertMode == true) { FinalBooga = InsertDamage +  (player.statDefense / (1 / .75f)); } 
            else if (Main.expertMode == false) { FinalBooga = InsertDamage + (player.statDefense / (1 / .5f)); }
//Add .4 because rounding wack
//Per usage, inflict 4 damage onto player (Ignores Defense)
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " turned to gel!"), (int)Math.Round(FinalBooga), 0);
            player.immune = false;
            player.immuneTime = 0;
            return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Gooeye>(), 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}