using System;
using System.Collections.Generic;
namespace AssignmentRockies
{
    class Program
    {
        static void Main(string[] args)
        {
        //1
         var maleMembers = GetMaleMember();
         Console.WriteLine("I.Danh sach nam:");
         PrintData(maleMembers);

        //2
         Console.WriteLine("II.Nguoi nhieu tuoi nhat:");
         var oldest = GetOldestMember();
         PrintData(new List<Member> {oldest});

        //3
        Console.WriteLine("III.Ho va ten:");
         var fullNames = GetFullMemberNames();
        for (int i = 0; i < fullNames.Count; i++)
        {
            string fullName = fullNames[i];
            Console.WriteLine($"{i+1} {fullName}");
        }
        
        //4
        var allList = SplitByYear();

        Console.WriteLine("VI.Nhung nguoi sinh nam 2000");
        PrintData(allList.Item1);

        Console.WriteLine("Nhung nguoi sinh truoc nam 2000");
        PrintData(allList.Item2);

        Console.WriteLine("Nhung nguoi sinh sau nam 2000");
        PrintData(allList.Item3);

        //5 
        Console.WriteLine("V.Nguoi dau tien sinh o Ha Noi:");
        var birthPlace = GetBirthPlace();
        PrintData(birthPlace);
        }

        static List<Member> members = new List<Member>
        {
            new Member
            {   
                Id = 1,
                FirstName = "Nam",
                LastName = "Hoang Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 10, 11),
                PhoneNumber = "0965976864",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member 
            {
                Id =  2,
                FirstName = "Son",
                LastName = "Nguyen Hung",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Thai Nguyen",
                IsGraduated = false
            },
             new Member 
            {   
                Id = 3,
                FirstName = "Phuong",
                LastName = "Tran Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 10, 11),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
             new Member 
            {
                Id = 4,
                FirstName = "Duong",
                LastName = "Hoang Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(1998, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
             new Member 
            {
                Id = 5,
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 1, 1),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Member 
            {
                Id = 6,
                FirstName = "Phong",
                LastName = "Le Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Member 
            {   
                Id = 7,
                FirstName = "Ha",
                LastName = "Le Ngoc",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 10, 22),
                PhoneNumber = "0965976864",
                BirthPlace = "Hai Phong",
                IsGraduated = false
            }
        };
         static void PrintData(List<Member> data)
        {
            foreach(var item in data)
            {
                Console.WriteLine($"{item.Id} {item.LastName} {item.FirstName} - {item.DateOfBirth.ToString("dd/MM/yyy")} - {item.Age}");
            }
        }
        static List<Member> GetMaleMember()
        {
            var result = new List<Member>();
            foreach (var member in members)
            {
                if (member.Gender == "Male")
                {
                    result.Add(member);
                }
            }
            return result;
        }

        static Member GetOldestMember() 
        {
            var maxDays = members[0].TotalDays;
            var maxAgeIndex = 0;
            for(var i = 1; i< members.Count; i++)
            {
                var member = members[i];
                if(member.TotalDays > maxDays)
                {
                    maxDays = member.TotalDays;
                    maxAgeIndex = i;
                }
            }
            return members[maxAgeIndex];
        }

        static List<String> GetFullMemberNames()
        {
            var ListFullName = new List<string>();
            foreach(var member in members)
            {
                ListFullName.Add($"{member.LastName} {member.FirstName}");
            } 
            return ListFullName;
        }

        static Tuple<List<Member>, List<Member>, List<Member>> SplitByYear()
        {   
            var list1 = new List<Member>();
            var list2 = new List<Member>();
            var list3 = new List<Member>();
            foreach (var member in members)
            {   
                var birthYear = member.DateOfBirth.Year;

                if(birthYear == 2000) {
                    list1.Add(member);
               } else if (birthYear > 2000)
               {
                    list2.Add(member);
               } else 
               {
                    list3.Add(member);
               }
            }
            return Tuple.Create(list1, list2, list3);
        }

        static List<Member> GetBirthPlace()
        {   
            var result = new List<Member>();
            var oldestHaNoi = new List<Member>();
            foreach (var member in members) 
            {
                if(member.BirthPlace == "Ha Noi")
                {
                    result.Add(member);
                }
            }
              var maxAge = result[0].TotalDays;
                    var maxAgeIndex = 0;
                    for(int i = 0; i<result.Count; i++)
                    {   
                        if(result[i].Age > maxAge){
                            maxAge = result[i].TotalDays;
                            maxAgeIndex = i;
                        }
                    }
            oldestHaNoi.Add(result[maxAgeIndex]);
            return oldestHaNoi;
        }
    }
}

