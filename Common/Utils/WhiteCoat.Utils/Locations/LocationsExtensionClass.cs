using System;

namespace WhiteCoat.Utils.Locations
{
    public static class LocationsExtensionClass
    {
        public const double MilesToKilometerMultiplier = 1.609344;
        public static double MilesToKilometer(this double miles) {
            return miles * MilesToKilometerMultiplier;
        }
        public static double DegreeToRadian(this double angle)
        {
            return Math.PI * angle / 180.0;
        }
        /// <summary>
        /// Returns Distance in miles between two geo points based on thier latitude and longitude 
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public static double Distance(double lat1, double lng1, double lat2, double lng2)
        {
            double earthRadius = 3958.75;
            //  in miles, change to 6371 for kilometer output
            double dLat = (lat2 - lat1).DegreeToRadian();
            double dLng = (lng2 - lng1).DegreeToRadian();
            double sindLat = Math.Sin((dLat / 2));
            double sindLng = Math.Sin((dLng / 2));
            double a = (Math.Pow(sindLat, 2)
                        + (Math.Pow(sindLng, 2)
                        * (Math.Cos(lat1.DegreeToRadian()) * Math.Cos( lat2.DegreeToRadian() ))));

            double c = (2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt((1 - a))));
            double dist = (earthRadius * c);
            return dist;
            //  output distance, in MILES
        }
        /// <summary>
        /// Returns Distance in meters between two geo points based on thier latitude and longitude 
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        public static double DistanceInMeters(double lat1, double lng1, double lat2, double lng2)
        {
            return Distance(lat1, lng1, lat2, lng2).MilesToKilometer()*1000;
        }
    }

}
