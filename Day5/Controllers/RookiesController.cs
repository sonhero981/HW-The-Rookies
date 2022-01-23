using Microsoft.AspNetCore.Mvc;
using Day5.Models;
using System.Globalization;
using CsvHelper;
using CsvHelper.TypeConversion;


namespace Day5.Controllers;
public class RookiesController : Controller 
{
      static List<Person> persons = new List<Person>
        {
            new Person
            {   
                Id = 1,
                FirstName = "Nam",
                LastName = "Hoang Van",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(2000, 10, 11),
                PhoneNumber = "0965976864",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Person 
            {
                Id =  2,
                FirstName = "Son",
                LastName = "Nguyen Hung",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(1999, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Thai Nguyen",
                IsGraduated = false
            },
             new Person 
            {   
                Id = 3,
                FirstName = "Phuong",
                LastName = "Tran Duc",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(1997, 10, 11),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
             new Person 
            {
                Id = 4,
                FirstName = "Duong",
                LastName = "Hoang Tuan",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(1998, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
             new Person 
            {
                Id = 5,
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(1999, 1, 1),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Person 
            {
                Id = 6,
                FirstName = "Phong",
                LastName = "Le Hong",
                Gender = Genders.Male,
                DateOfBirth = new DateTime(2002, 10, 31),
                PhoneNumber = "0965976864",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Person 
            {   
                Id = 7,
                FirstName = "Ha",
                LastName = "Le Ngoc",
                Gender = Genders.Female,
                DateOfBirth = new DateTime(1999, 10, 22),
                PhoneNumber = "0965976864",
                BirthPlace = "Hai Phong",
                IsGraduated = false
            }
        };



        
        public IActionResult Index()
        {
            return View(persons);
        }

        [Route("rookies/male")]
        public IActionResult GetMalePersons() 
        {
            var results = (from person in  persons
                    where person.Gender == Genders.Male
                    select person
                    ).ToList();
            return new ObjectResult(results);
        }


        [Route("rookies/oldest")]
        public IActionResult GetOldestPersons() 
        {
             var result = persons.Max(person => person.TotalDays);
            var personoldest = persons.First(person => person.TotalDays==result);
            return new ObjectResult(personoldest);
        }

        [Route("rookies/fullName")]
        public IActionResult GetFullName() 
        {
           var fullNames = from person in persons
                            orderby person.FullName
                            select person.FullName;
            return new ObjectResult(fullNames);
        }

        [Route("rookies/splitbyyear")]
        public IActionResult SpitByYear(int year) 
        {
           
            var list1 = (from person in persons
                        where person.DateOfBirth.Year == year
                        select person).ToList();
            
            var list2 = (from person in persons
                        where person.DateOfBirth.Year > year
                        select person).ToList();

            var list3 = (from person in persons
                        where person.DateOfBirth.Year < year
                        select person).ToList();

         var listSplit = Tuple.Create(list1, list2, list3);
         return new ObjectResult(listSplit);
        }


    [Route("rookies/export")]
   public IActionResult Export()
    {
        var buffer =  WriteCsvToMemory(persons);
        var memoryStream = new MemoryStream(buffer);
        return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "export.csv" };
    }

    byte[] WriteCsvToMemory(List<Person> data)
    {
        using (var stream = new MemoryStream())
        using (var writer = new StreamWriter(stream))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyy" } };
            csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

            csvWriter.WriteRecords(data);
            writer.Flush();
            return stream.ToArray();
        }
    }
}