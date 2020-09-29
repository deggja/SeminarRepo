using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seminarapi.Models;

namespace seminarapi.Data
{
    public class DbSeeder
    {
        public static void Seed(SeminarContext context)
        {
            context.Database.EnsureCreated();

            /* Check if seeded
            if (context.Courses.Any())
            {
                return; Db already seeded
            } */

            var courses = new Course[]
            {
                new Course{Name="Blomsterseminar", Room="Fjellknas", StartTime=DateTime.Parse("2018-01-01"), EndTime=DateTime.Parse("2018-01-01") },
                new Course{Name="Blomsterseminar", Room="Fjellknas", StartTime=DateTime.Parse("2018-01-01"), EndTime=DateTime.Parse("2018-01-01") },
                new Course{Name="Blomsterseminar", Room="Fjellknas", StartTime=DateTime.Parse("2018-01-01"), EndTime=DateTime.Parse("2018-01-01") },
                new Course{Name="Blomsterseminar", Room="Fjellknas", StartTime=DateTime.Parse("2018-01-01"), EndTime=DateTime.Parse("2018-01-01") },
                new Course{Name="Blomsterseminar", Room="Fjellknas", StartTime=DateTime.Parse("2018-01-01"), EndTime=DateTime.Parse("2018-01-01") },
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var participants = new Participant[]
            {
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
                new Participant{FirstName="Geir", LastName="Bakke", Email="geir@bakke.no" },
            };
            foreach (Participant p in participants)
            {
                context.Participants.Add(p);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor{FirstName="Nils", LastName="Narvik" },
                new Instructor{FirstName="Nils", LastName="Narvik" },
                new Instructor{FirstName="Nils", LastName="Narvik" },
                new Instructor{FirstName="Nils", LastName="Narvik" },
                new Instructor{FirstName="Nils", LastName="Narvik" },
                new Instructor{FirstName="Nils", LastName="Narvik" },
            };
            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{ParticipantID=1, CourseID=1 },
                new Enrollment{ParticipantID=2, CourseID=1 },
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{LocationName="Oslo", LocationCountry="Norway" },
                new Location{LocationName="Bergen", LocationCountry="Norway" },
            };
            foreach (Location i in locations)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();
        }
    }
}
