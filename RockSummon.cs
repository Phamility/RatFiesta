
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RatFiesta.Minions
{
	class RockSummon : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock");
			// Sets the amount of frames this minion has on its spritesheet
			Main.projFrames[projectile.type] = 1;
			// This is necessary for right-click targeting
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			// These below are needed for a minion
			// Denotes that this projectile is a pet or minion
			Main.projPet[projectile.type] = true;
			// This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			// Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public sealed override void SetDefaults()
		{
			projectile.width = 17;
			//projectile.aiStyle = 54;
			//aiType = NPCID.Raven;


			projectile.height = 17;
			// Makes the minion go through tiles freely
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			// These below are needed for a minion weapon
			// Only controls if it deals damage to enemies on contact (more on that later)
			projectile.friendly = true;
			// Only determines the damage type
			projectile.minion = true;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			projectile.minionSlots = 0f;
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			
		}
		public override bool? CanCutTiles()
		{
			return false;
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
		
		public override void AI()
		{

			Player player = Main.player[projectile.owner];

			projectile.position.X += (Main.rand.Next(16,64));



			Vector2 idlePosition = (player.Center);
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			int lecock = (Main.rand.Next(50, 450));
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 450)
			{
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition + new Vector2(-449, (lecock - 250)); 
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<RockBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<RockBuff>()))
			{
				projectile.timeLeft = 2;
			}
			projectile.rotation = projectile.velocity.X * 3f;
		}
	}
}

