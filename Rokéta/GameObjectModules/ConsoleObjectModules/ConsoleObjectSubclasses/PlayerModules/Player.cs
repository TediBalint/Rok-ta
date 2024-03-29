﻿using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.AnimationModules.AnimationSubclasses;
using Rokéta.SoundModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Player : ConsoleObject
    {
        public Weapon Weapon { get; private set; }
		public double[] MovementSpeed { get; private set; }
        private readonly Booster booster;
        public Player(double x, double y, int zIndex, int width, int height, string? filePath, double[] _movementSpeed, Booster _booster)
        : base(x, y, zIndex, width, height, filePath)
        {
            booster = _booster;
            MovementSpeed = _movementSpeed;
            ChangeWeapon(GetCurrentWeapon());
            Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\PlayerDeathAnim.txt", this));
            Animations.Add(new BoosterAnim(this,_booster));
        }
        public void MoveRaw(int[] sgn)
        {
            if (IsMovable)
            {
                X += MovementSpeed[0] * sgn[0];
                Y -= MovementSpeed[1] * sgn[1];
                Snap();
            }
            Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width) / 2, Y };
        }
        public void ChangeWeapon(Weapon newWeapon)
        {
            Weapon = newWeapon;
            Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width) / 2, Y };
        }
        private void Death()
        {
            CanCollide = false;
            IsVissible = false;
            IsMovable = false;
            Animations[0].IsPaused = false;
            Animations[1].IsPaused = true;
            SoundManager.PlaySound($"PlayerDeathSound{Globals.Random.Next(1, 5 + 1)}");
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
                catch (NullReferenceException e)
                {
                    Debug.WriteLine($"Common error in Snap (Player.cs):\n{e.Message}");
                }
            }
        }
        protected override string getSaveString()
        {
            Debug.WriteLine(booster.FilePath);
            return base.getSaveString() + $";{MovementSpeed[0]};{MovementSpeed[1]};{booster.Name}";
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
		public override void Update(ref CharInfo[] pixels)
		{
			base.Update(ref pixels);
			ChangeWeapon(GetCurrentWeapon());
		}
		public override void OnCollision(ConsoleObject otherObject)
        {
            if (CanCollide)
            {
                if (otherObject.GetType().Name == "Enemy")
                {
                    Death();
                }
            }
        }
    }
}
