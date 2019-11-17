using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDataProcessor
{
    public enum LocationDataType
    {
        Event_Type = 1,
        Timestamp = 2,
        User_ID = 3,
        Advertising_ID = 4,
        Advertising_ID_Type = 5,
        Ad_Tracking_Enabled = 6,
        Latitude = 7, // was 10
        Longitude = 8, // was 11
        Dwell = 9,
        Current_Hex = 10, // was 7
        Previous_Hex = 11, // was 8
        Horizontal_Accuracy = 12,
        Speed = 13,
        Bearing = 14,
        IP_Address = 15,
        Connection_Type = 16,
        Connection_Wifi_SSID = 17,
        Connection_Wifi_BSSID = 18,
        Location_Method = 19,
        Device_Manufacturer = 20,
        Device_Model = 21,
        OS = 22,
        OS_Version = 23,
        Altitude = 24,
        Device_Language = 25,
        App_ID = 26
    }
}
