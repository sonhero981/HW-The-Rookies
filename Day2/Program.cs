using System;
using System.Collections.Generic;
using System.Linq;
namespace AssignmentRockies
{   

    class Program
    {
        static void Main(string[] args)
        {
          int selectNumber;
          do 
          {
              Console.WriteLine("-------------Menu--------------");
              Console.WriteLine("1.Danh sach nam");
              Console.WriteLine("2.Nguoi nhieu tuoi nhat");
              Console.WriteLine("3.Ho va ten");
              Console.WriteLine("4.Danh sach nguoi sinh truoc sau va trong nam 2000");
              Console.WriteLine("5.Nguoi dau tien o Ha Noi");
              Console.WriteLine("6.Thoat");
              selectNumber = int.Parse(Console.ReadLine());

              switch(selectNumber)
              {
                case 1:
                    //1
                    var maleMembers = GetMaleMember();
                    Console.WriteLine("I.Danh sach nam:");
                    PrintData(maleMembers);
                    break;

                case 2:
                    Console.WriteLine("II.Nguoi nhieu tuoi nhat:");
                    var oldest = GetOldestMember();
                    PrintData(new List<Member> {oldest});
                    break;

                case 3:
                    Console.WriteLine("III.Ho va ten:");
                    var fullNames = GetFullMemberNames();
                    for (int i = 0; i < fullNames.Count; i++)
                    {
                        string fullName = fullNames[i];
                        Console.WriteLine($"{i+1} {fullName}");
                    }
                    break;

                case 4:        
                    var allList = SplitByYear(2000);

                    Console.WriteLine("VI.Nhung nguoi sinh nam 2000");
                    PrintData(allList.Item1);

                    Console.WriteLine("Nhung nguoi sinh truoc nam 2000");
                    PrintData(allList.Item2);

                    Console.WriteLine("Nhung nguoi sinh sau nam 2000");
                    PrintData(allList.Item3);
                    break;

                case 5:
                    Console.WriteLine("V.Nguoi dau tien sinh o Ha Noi:");
                    var birthPlace = GetBirthPlace("Ha Noi");
                    PrintData(new List<Member> {birthPlace});
                    break;
                
                case 6:
                    break;
                
                default:
                    Console.WriteLine("Vui long nhap lai");
                    break;
              }

          } while(selectNumber !=6);
          Console.ReadLine();
          
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
            var result = members.Where(member => member.Gender == "Male").ToList();
            return result;
        }

        static Member GetOldestMember() 
        {
            var result = members.Max(member => member.Age);
            return members.First(member => member.Age==result);
        }

        static List<String> GetFullMemberNames()
        {
            var fullNames = members.Select(member => member.FullName);
            return fullNames.ToList();
        }

        static Tuple<List<Member>, List<Member>, List<Member>> SplitByYear( int year)
        {   
            var list1 = members.Where(member => member.DateOfBirth.Year == year).ToList();
            var list2 = members.Where(member => member.DateOfBirth.Year == year).ToList();
            var list3 = members.Where(member => member.DateOfBirth.Year == year).ToList();
            
            return Tuple.Create(list1, list2, list3);
        }

        static Member GetBirthPlace(string place)
        {   
            return members.First(member => member.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

