/* Purpose: gym membership
 * Athor: Mahjabin Sajadi
 * Date: 18-April-2021
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_Mahjabin_Sajadi_3P1
{
    class GymMember
    {
        private string name;
        private string Membership_Status;
        private string Membership_code;

   
        public GymMember()  //default Constructor
        {
            name = "No Name";
            Membership_Status = "None";
            Membership_code = "000";
        }

        public GymMember(string n_name, string n_Membership_Status,string n_Membership_code)  //overloaded Constructor which brings in the parameters
        //: this()
        {
            //n_  stands for new
            name = n_name;
            Membership_Status = n_Membership_Status;
            Membership_code = n_Membership_code;
        }
        public string Getname()
        {
            return name;
        }
        public string Getstat()
        {
            return Membership_Status;
        }
        public void DisplayMemberInformation()
        {
          
            Console.WriteLine("The name Is: " + name +", member status is "+ Membership_Status +", and Member code is "+ Membership_code); 
        }
        public bool Compare(string usercode )
        {
            if (Membership_code == usercode)
                return true;
            else
                return false;

        }
        public bool isempty()
        {
            if (name == "No Name")
                return true;
            else
                return false;

        }

    }


}

