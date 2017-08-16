using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyClient
{
    public class EmergencyInfo
    {
        public string userName;
        public string department;
        public string status;
        public string messageCount;
        public string userGroup;
        public string latitude;
        public string longitude;
        public string email;

        public EmergencyInfo(string newUserName, string newDepartment, string newStatus, string newMessageCount, 
                            string newUserGroup, string newLongitude, string newLatitude, string newEmail)
        {
            userName = newUserName;
            department = newDepartment;
            status = newStatus;
            messageCount = newMessageCount;
            userGroup = newUserGroup;
            longitude = newLongitude;
            latitude = newLatitude;
            email = newEmail;
        }

        public EmergencyInfo()
        {

        }
    }
}
