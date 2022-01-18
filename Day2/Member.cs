using System;
namespace AssignmentRockies {   
        public class Member : IComparable{
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public  string Gender {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string PhoneNumber {get; set;}
        public string BirthPlace {get; set;}
        public bool IsGraduated {get; set;}

        public string FullName
        {
            get {
                return LastName+" " +FirstName;
            }
        }
        public int Age 
        {
            get 
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

        public int TotalDays {
            get {
                return (int)(DateTime.Now - DateOfBirth).TotalDays;
            }
        }
        
        public int CompareTo(object obj)
        {
            return TotalDays.CompareTo(obj);
        }
    }   
}

