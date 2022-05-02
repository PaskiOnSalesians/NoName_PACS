using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalVariables
{
    public class RefVariables
    {
        #region Planetes

        public static int PlanetId { get; set; }
        public static string PlanetName { get; set; }
        public static string PlanetCode { get; set; }
        public static string PlanetIp { get; set; }
        public static int PlanetMessagePort { get; set; }
        public static int PlanetFilePort { get; set; }
        public static string PlanetImage { get; set; }

        #endregion

        #region Naus

        public static int ShipId { get; set; }
        public static string ShipName { get; set; }
        public static string ShipIp { get; set; }
        public static int ShipMessagePort { get; set; }
        public static int ShipFilePort { get; set; }
        public static string ShipImage { get; set; }

        #endregion

        #region Delivery Codes

        public static string DeliveryCode { get; set; }

        #endregion

        public static bool CanEnter { get; set; }
    }
}
