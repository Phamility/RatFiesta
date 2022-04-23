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
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Accessories.TGlass;


namespace RatFiesta.Items.Weapons

{
    public class ADrainGun2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Spirit Shotgun");
            Tooltip.SetDefault("Costs 10 Health for each shot!\n50% chance to not consume ammo.\nI begged to be adored.\nAn indescribale message from A Mysterious Force can be heard in your head.\nThe message gives you the thoughts of 'Very' 'Accomplishment' 'Lifetime' and 'Power'");
        }

        public override Vector2? HoldoutOffset()
        {
            {
                return new Vector2(-5, 0);
            }
        }
        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.TacticalShotgun);
            item.damage = 333;
            item.ranged = true;
            item.width = 70;
            item.height = 28;
            item.maxStack = 1;
            item.useTime = 25;
            item.useAnimation = 25;
            // item.useStyle = 5;
            // item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 12);
            item.rare = ItemRarityID.Expert;
            item.UseSound = SoundID.Item38;
            item.noMelee = true;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            item.useAmmo = AmmoID.Bullet;
            //      item.shootSpeed = 4f;
            item.autoReuse = true;
        }
        public float InsertDamage = 10.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public float Glass1;
        public float Glass2;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY) * 25);
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            InsertDamage = 10.4f;

           
            
            if (Main.expertMode == true) { FinalBooga = InsertDamage + (player.statDefense / (1 / .75f)); }
            else if (Main.expertMode == false) { FinalBooga = InsertDamage + (player.statDefense / (1 / .5f)); }
            //Add .4 because rounding wack
            //Per usage, inflict 4 damage onto player (Ignores Defense)
            if (player.GetModPlayer<ExamplePlayer>().BreastWorn == true) { }
            else
            {
                player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " used too much of their soul!"), (int)Math.Round((FinalBooga + player.GetModPlayer<ExamplePlayer>().EnduranceForDrainGun2)), 0);
                player.immune = false;
                player.immuneTime = 0;
            }
            int numberProjectiles = 6;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
           // return true;

        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .50f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.TacticalShotgun);
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddIngredient(ItemID.FragmentVortex, 4);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}