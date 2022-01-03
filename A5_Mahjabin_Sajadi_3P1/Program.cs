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
    class Program
    {
        static void Main(string[] args)
        {
            /************Definiton Variables*************/
            string Memb_Code = "";   //number of gym members at the first time the user enter
            string Name="", Membership_Status="", Name_edit = "", Membership_Status_edit = "";
            int Memb_Code_int = 0, Membership_Status_int = 0, spot=-1;
            bool flag_main = true;  // check the main loop
            string Class_Option = " ";  // Choose one option of the Main menu
            bool flag_option_A = true;  // check option A
            bool flag_C = true;  // check option C
            bool flag_name; // check the name in option A
            bool flag_status;   // check the status flag
            string first_init = "", lastName_init = "", index_Code = "";

            /********************** Main Process*********************/

            Console.WriteLine("Please Enter Number of Gym Members");
            string Memb_num = Console.ReadLine();
            int Memb_num_int = int.Parse(Memb_num);

            GymMember[] Gym_list = new GymMember[Memb_num_int];

            for (int k = 0; k < Memb_num_int; k++)
            {
                Gym_list[k] = new GymMember();

            }

            do
            {
                try
                {

                    Console.WriteLine("Main Menu \n");
                    Console.WriteLine("Enter\"A\" if you want to Add new Member (Name,Membership Status, Membership Code)");
                    Console.WriteLine("Enter\"B\" if you want to Edit an Existing Member Record");
                    Console.WriteLine("Enter\"C\" if you want to Display name, MembershipStatus, and MemberShipCode that Already Exist");
                    Console.WriteLine("Enter\"D\" if you want to Exit the program");
                    Class_Option = Console.ReadLine();

                }
                catch (FormatException fEx)

                {
                    Console.WriteLine("Your Input is Incorrect!Enter number again");
                }
                switch (Class_Option)
                {
                    case "A":
                    case "a":
                        flag_option_A = true;
                        while (flag_option_A)
                        {
                            flag_option_A = true;

                            try
                            {
                                if (spot < Gym_list.Length)
                                {
                                    Console.WriteLine("Making membership code by this pattern \"z+FirstInitial+LastNameInitial\"");
                                    Console.WriteLine("Please enter FirstInitial  ");
                                    first_init = Console.ReadLine();
                                    first_init = first_init.ToUpper();
                                    first_init = first_init.Trim();
                                    Console.WriteLine("Please enter LastNameInitial  ");
                                    lastName_init = Console.ReadLine();
                                    lastName_init = lastName_init.ToUpper();
                                    lastName_init = lastName_init.Trim();
                                    Console.WriteLine("Please Enter\"index membership num\",Enter (You can enter \"QUIT\" to exit program)");
                                    index_Code = Console.ReadLine();


                                    if (index_Code == "QUIT" || index_Code == "quit")
                                    {
                                        flag_option_A = false;
                                    }
                                    else
                                    {
                                        int index_Code_int = int.Parse(index_Code);
                                        /******************/

                                        Memb_Code = "z" + first_init + lastName_init + index_Code;
                                        Console.WriteLine("Your Member ship Code that you entered is: " + Memb_Code);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" The List is Full! You cannot Add More Gym Member ");
                                    flag_option_A = false;
                                }
                            }
                            catch (FormatException fEx)
                            {
                                Console.WriteLine("Your Input is Incorrect!Enter number again");
                            }
                            catch (OverflowException oEx)
                            {
                                Console.WriteLine("the number should be smaller");
                            }


                            if (flag_option_A == true)
                            {
                                int pre_reg = -1;  //check previous registration and avoid repetitive
                                bool Already_registered = false;
                                for (int i = 0; i < Gym_list.Length; i++)
                                {

                                    bool result = Gym_list[i].Compare(Memb_Code);

                                    if (result == true && Already_registered == false)
                                    {
                                        pre_reg = i; // find pre registeration
                                        Already_registered = true;
                                        Console.WriteLine("Error! MemberShip Code already registered");

                                    }
                                }

                                /********************************New Registration*****************************************************/

                                if (Already_registered == false)

                                {
                                    try
                                    {
                                        spot = -1;
                                        for (int k = 0; k < Gym_list.Length; k++)
                                        {
                                            bool Empty = Gym_list[k].isempty();  //New Registration

                                            if (Empty == true && spot == -1)
                                            {
                                                spot = k;
                                            }
                                        }
                                        if (spot != -1)
                                        {
                                            flag_name = true;
                                            while (flag_name)

                                            {
                                                flag_name = false;
                                                Console.WriteLine("You can do Compelet Registration Proccess");
                                                Console.WriteLine("Please Enter Your Name, Ex: Bill Anderson");
                                                Name = Console.ReadLine();
                                                string[] spliting = Name.Split(' ');   // split first name from last name

                                                if (spliting[1].Length < 2)            // family length
                                                {
                                                    Console.WriteLine("the format is wrong , we anticipate family name with atleast two characters");
                                                    int m = spliting[1].Length / 0;
                                                }
                                                string first_name = spliting[0];
                                                first_name = first_name.ToUpper();
                                                string last_name = spliting[1];
                                                last_name = last_name.ToUpper();
                                                Console.WriteLine(last_name);

                                                /********Check Initials******/
                                                if (Convert.ToChar(first_name[0]) != Convert.ToChar(first_init))
                                                {
                                                    Console.WriteLine(" Your First Name Should be start with \" " + first_init + "\"");
                                                    flag_name = true;
                                                }
                                                if (Convert.ToChar(last_name[0]) != Convert.ToChar(lastName_init))
                                                {
                                                    Console.WriteLine(" Your First Name Should be start with \" " + lastName_init + "\"");
                                                    flag_name = true;
                                                }
                                            }
                                            flag_status = true;
                                            while (flag_status)
                                            {
                                                flag_status = false;
                                                Console.WriteLine("Please Enter Your MemberShip Status, Ex: \"A\"-Active,\"S\"-Suspended,\"N\"-nonActive");
                                                Membership_Status = Console.ReadLine();
                                                Membership_Status = Membership_Status.ToUpper();
                                                if (Membership_Status.Length != 1)
                                                {
                                                    Console.WriteLine(" The status should be exact one Charachter \"A\"-Active,\"S\"-Suspended,\"N\"-nonActive ");
                                                    flag_status = true;
                                                }

                                            }
                                            Gym_list[spot] = new GymMember(Name, Membership_Status, Memb_Code);
                                            Gym_list[spot].DisplayMemberInformation();
                                            flag_option_A = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine(" The List is Full! You cannot Add More Gym Member ");
                                            flag_option_A = false;

                                        }

                                    }

                                    catch (FormatException fEx)
                                    {
                                        Console.WriteLine("The input is incorrect,Enter number again");
                                    }
                                    catch (OverflowException oEx)
                                    {
                                        Console.WriteLine("the number should be smaller");
                                    }
                                    catch (DivideByZeroException oEx)
                                    {
                                        Console.WriteLine("Change format");
                                    }
                                    catch (IndexOutOfRangeException e)
                                    {
                                        Console.WriteLine("needed \" \" in the string");
                                    }
                                } 
                            

                            }
                        }

                        break;

                    /********************Option B _ Edition*********************/
                    case "B":
                    case "b":
                        Console.WriteLine("Please Enter Your Membership Code, \"ex: zMS1\" ");
                        Memb_Code = Console.ReadLine();
                        if (Memb_Code.Length < 4)
                        {
                            Console.WriteLine("Error! Your Code is too shor, should be at least 4");
                        }
                        bool flag_B = true;
                        while (flag_B)
                        {
                            int pre_reg = -1;  //check previous registration and avoid repetitive
                            bool Already_registered = false;
                            for (int i = 0; i < Gym_list.Length; i++)
                            {

                                bool result = Gym_list[i].Compare(Memb_Code);

                                if (result == true && Already_registered == false)
                                {
                                    pre_reg = i; // find pre registeration
                                    Already_registered = true;
                                    Console.WriteLine("MemberShip Code found, If You Want You Can Edit Your Info.");
                                    Console.WriteLine("Please Choose which part of your data need to changee? Enter \" N\" if you want to change the Name & \n \"M\" if you want to change the Membership Status \n \"B\" if you want to change both");
                                    string Edition = Console.ReadLine();
                                    Name_edit = Gym_list[i].Getname();
                                    Membership_Status_edit = Gym_list[i].Getstat();
                                    if (Edition == "N" || Edition == "B" || Edition == "n" || Edition == "b")
                                    {
                                        Console.WriteLine("Please Enter Your Name, Ex: Bill Anderson");
                                        Name_edit = Console.ReadLine();
                                    }
                                    if (Edition == "M" || Edition == "b" || Edition == "m" || Edition == "B")
                                    {
                                        Console.WriteLine("Please Enter Your MemberShip Status, Ex: \"A\"-Active,\"S\"-Suspended,\"N\"-nonActive");
                                        Membership_Status_edit = Console.ReadLine();
                                    }

                                    Gym_list[pre_reg] = new GymMember(Name_edit, Membership_Status_edit, Memb_Code);
                                    Gym_list[pre_reg].DisplayMemberInformation();
                                    flag_B = false;
                                }
                                else
                                {
                                    Console.WriteLine("Your record does not exist");
                                }


                            }

                        }
                        break;
                    /********************Option C_Display*********************/
                    case "C":
                    case "c":
                        flag_C = true;

                        while (flag_C)
                        {
                        Console.WriteLine("Please Enter Your Membership Code, \"ex: zMS1\" ");
                        string Mem_Code_Display = Console.ReadLine();
                        if (Mem_Code_Display.Length < 4)
                        {
                            Console.WriteLine("Error! Your Code is too shor, should be at least 4");
                        }
                        else if (Memb_Code == "QUIT"|| Memb_Code == "quit")
                        {
                            flag_C = false;
                        }
                        else
                        {

                                flag_C = true;
                                int pre_reg = -1;  //check previous registration and avoid repetitive
                                bool Already_registered = false;
                                for (int i = 0; i < Gym_list.Length; i++)
                                {

                                    bool result = Gym_list[i].Compare(Memb_Code);
                                    Console.WriteLine(result);
                                    if (result == true && Already_registered == false)
                                    {
                                        pre_reg = i; // find pre registeration
                                        Already_registered = true;
                                        Console.WriteLine("MemberShip Code found");
                                        flag_C = false;
                                        Gym_list[pre_reg].DisplayMemberInformation();
                                        Console.WriteLine("Please press Enter or any kry to continue");
                                        Console.ReadKey();
                                    }
                                   
                                }
                                 if (Already_registered == false)
                                {
                                    Console.WriteLine("Error! No member record exist, please try again");

                                    flag_C = true;

                                }

                            }
                        }
                        break;
                    /********************Option D_Exit *********************/
                    case "D":
                    case "d":
                        //Option E
                        flag_main = false;
                        break;

                    case "":


                        Console.WriteLine("Could not be null, Please select between A, B, C, D ");
                        break;
                    default:
                        Console.WriteLine("Out of Range Error, Please select between A, B, C, D ");
                        break;

                }

            } while (flag_main);
            Console.ReadKey();


        }
    }
}
