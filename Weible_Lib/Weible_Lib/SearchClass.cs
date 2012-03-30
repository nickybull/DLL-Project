namespace Weible_Lib
{
    public class SearchClass
    {
        static System.String city;
        /// <summary>
        /// This sets the city name that the users wishes to search for
        /// </summary>
        /// <param name="check">the city name</param>
        public static void setSearch(System.String check)
        {
            city = check;
        }
        /// <summary>
        /// This puts the city name into the link and returns the link
        /// </summary>
        /// <returns>The completed link</returns>
        public static System.String getLink()
        {
            System.String temp = "http://www.ncdc.noaa.gov/cdo-services/services/datasets/NORMAL_DLY/search?token=LbfduyTKitQPttYdupQHgABJwloOGhLK?text=" + city;
            return temp;
        }
    }
}


