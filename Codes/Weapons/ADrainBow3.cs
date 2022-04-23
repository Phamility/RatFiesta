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
    public class ADrainBow3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guide's Wrath");
            Tooltip.SetDefault("Costs 15 Health for each arrow!\nWith every shot, you can feel your skin start to tear.");
        }

        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.WoodenBow);
            item.damage = 275;
            item.ranged = true;
            item.width = 24;
            item.height = 56;
            item.maxStack = 1;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.NPCHit9;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 20f;
            item.autoReuse = true;
        }
        public float InsertDamage = 15.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            InsertDamage = 15.4f;
            if (player.HasBuff(114) == true)
            {
                Tenpercent = 1;
            }
            else
            {
                Tenpercent = 0;
            }
            if (Main.expertMode == true) { FinalBooga = InsertDamage + (player.statDefense / (1 / .75f)); }
            else if (Main.expertMode == false) { FinalBooga = InsertDamage + (player.statDefense / (1 / .5f)); }
            //Add .4 because rounding wack
            //Per usage, inflict 4 damage onto player (Ignores Defense)
            player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " ran out of flesh!"), (int)Math.Round(FinalBooga + player.GetModPlayer<ExamplePlayer>().EnduranceForDrainBow3), 0);
            player.immune = false;
            player.immuneTime = 0;
            return true;

        }

    
    }
}