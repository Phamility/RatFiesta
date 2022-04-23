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
    public class ADrainBow4 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Tranquility");
            Tooltip.SetDefault("Heals 2 health for each arrow!\nDrown in the sound.\nDrown in nature.\nDrown in arrows.");
        }

        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.WoodenBow);
            item.damage = 75;
            item.ranged = true;
            item.width = 30;
            item.height = 56;
            item.maxStack = 1;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 200000;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 6;
            item.autoReuse = true;
        }
        public float InsertDamage = 4.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            /*  InsertDamage = 4.4f;
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
              player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " turned to gel!"), (int)Math.Round(FinalBooga + Tenpercent), 0);
              player.immune = false;
              player.immuneTime = 0;
            */
            if (player.statLife != player.statLifeMax2)
            {
                player.HealEffect(2);
            }
            player.statLife += 2;
            return true;

        }


    }
}