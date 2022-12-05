using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private List<string> targets;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name 
        {
            get => name;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; set; }

        public double Speed { get; set; }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (string.IsNullOrWhiteSpace(target.ToString()))
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.targets.Add(target.ToString());
        }

        public void RepairVessel()
        {
            this.ArmorThickness = ArmorThickness;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");
            if (!targets.Any())
            {
                sb.AppendLine("*Targets: None");
            }
            else
            {
                foreach (var target in targets)
                {
                    sb.AppendLine($"*Targets: {target}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
