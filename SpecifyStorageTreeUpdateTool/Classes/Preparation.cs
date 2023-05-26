using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecifyStorageTreeUpdateTool
{
    // https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1.equals?view=netframework-4.7.2
    public class Preparation : IEquatable<Preparation>
    {
        private int prepID;
        private string displayString;

        public Preparation() { }

        public Preparation(int prepID, string DisplayString)
        {
            this.prepID = prepID;
            this.displayString = DisplayString;
        }
        
        public int PrepID { get { return prepID; } }

        public string DisplayString { get { return displayString; } }

        public bool Equals(Preparation other)
        {
            if (other == null)
                return false;

            if (this.PrepID == other.PrepID)
                return true;
            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Preparation preparationObj = obj as Preparation;
            if (preparationObj == null)
                return false;
            else
                return Equals(preparationObj);
        }

        public override int GetHashCode()
        {
            return this.PrepID.GetHashCode();
        }

        public static bool operator == (Preparation preparation1, Preparation preparation2)
        {
            if (((object)preparation1) == null || ((object)preparation2) == null)
                return Object.Equals(preparation1, preparation2);

            return preparation1.Equals(preparation2);
        }

        public static bool operator != (Preparation preparation1, Preparation preparation2)
        {
            if (((object)preparation1) == null || ((object)preparation2) == null)
                return !Object.Equals(preparation1, preparation2);

            return !(preparation1.Equals(preparation2));
        }
    }
}
