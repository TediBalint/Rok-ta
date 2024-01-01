using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.SoundModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Player : ConsoleObject
    {
        //public PlayerStats Stats { get; set; }
        public Weapon Weapon { get; private set; }        
        public Player(double x, double y, int zIndex, int width, int height, string? filePath)
        : base(x, y, zIndex, width, height, filePath)
        {
			ChangeWeapon(GetCurrentWeapon());
			//setStats();
			Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\PlayerDeathAnim.txt", this, _destroyParent:true));
			Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\PlayerIdleAnim.txt", this, true));
        }
		public override void MoveRaw(double x, double y)
		{
			base.MoveRaw(x, y);
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width)/2, Y};
		}
		public void ChangeWeapon(Weapon newWeapon)
		{
			Weapon = newWeapon;
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width) / 2, Y };
		}
		private void Death()
		{
			canCollide = false;
			IsVissible = false;
			isMovable = false;
			Animations[0].IsPaused = false;
			Animations[1].IsPaused = true;
			SoundManager.PlaySound("PlayerDeathSound1");
			//SoundManager.PlaySound($"PlayerDeathSound{Globals.Random.Next(1,5+1)}");
		}
		public override void Snap()
		{
			if (Animations[1].currObject == null)
			{
				base.Snap();
			}
			else
			{
				try
				{
					if (Animations[1].currObject == null)
					{
						
						return;
					}
					X = Math.Min(X, Console.WindowWidth - Math.Max(Width, Animations[1].currObject.Width));
					X = Math.Max(X, 0);
					Y = Math.Min(Y, Console.WindowHeight - Height - Animations[1].currObject.Height + 1);
					Y = Math.Max(Y, 0);
				}
				catch (Exception e)
				{
					
					
				}
				
			}
			
		}
		public override bool isCollision(ConsoleObject otherObject)
		{
			bool animIsColliding = false;
			if(Animations[1].currObject != null)
			{
				animIsColliding = Animations[1].currObject.isCollision(otherObject);
			}
			return base.isCollision(otherObject) || animIsColliding;
		}
		
		public static Weapon GetCurrentWeapon()
		{
            // weapons is backwards
            foreach (int key in Defaults.weapons.Keys)
            {
				if (Globals.kills >= key) return Defaults.weapons[key];
            }
			return Defaults.weapons.Last().Value;
        }
		public override void OnCollision(ConsoleObject otherObject)
        {
			
			if (canCollide)
			{
				if (otherObject.GetType().Name == "Enemy")
				{
					Death();
				}
				else if (otherObject.GetType().Name == "Background")
				{
					ChangeWeapon(GetCurrentWeapon());
					return;
				}
			}
            
		}
    }
}
