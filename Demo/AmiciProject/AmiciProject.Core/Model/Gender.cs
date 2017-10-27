using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiciProject.Core
{
    public struct Gender:IEquatable<Gender>
    {
        public static readonly Gender Male = new Gender(MALE);
        public static readonly Gender Female  = new Gender(FEMALE);

        const string MALE = "M";
        const string FEMALE = "F";

        private readonly string value;
        public Gender(string gender)
        {
            this.value = gender;
            Validate(gender);
        }

        public static implicit operator Gender(string gender)
        {
            return new Gender(gender);
        }

        public static implicit operator string(Gender gender)
        {
            return gender.value;
        }
        public static bool operator ==(Gender g1, Gender g2)
        {
            return g1.value == g2.value;
        }

        public static bool operator !=(Gender g1, Gender g2)
        {
            return g1.value != g2.value;
        }

        public override string ToString()
        {
            return value;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public bool Equals(Gender g)
        {
            return value == g.value;
        }

        private void Validate(string gender)
        {
            if (gender != MALE && gender != FEMALE)
                throw new ArgumentException($"Il valore specificato per il genere deve essere '{MALE}' o '{FEMALE}'");
        }
    }
}
