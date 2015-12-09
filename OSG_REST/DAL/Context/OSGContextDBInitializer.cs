using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;

namespace DAL.Context
{
    public class OSGContextDBInitializer : DropCreateDatabaseAlways<OSGContext>
    {

        protected override void Seed(OSGContext context)
        {

            //Trainers
            var event1 = new Event()
            {
                Id = 1,
                Description = "Event event...dfddff",
                Title = "Event with trainer",
                Date = DateTime.Now
            };
            event1 = context.Event.Add(event1);
            var trainer1 = new Trainer()
            {
                FirstName = "Mikkel",
                LastName = "Madsen",
                Email = "mikkel@mail.com",
                PhoneNo = "22334455",
                Events = new List<Event>() { event1 }
            };

            context.Trainer.Attach(trainer1);
            context.Trainer.Add(trainer1);

            context.Trainer.Add(new Trainer()
            {
                FirstName = "Test First Name 1",
                LastName = "Test Last Name 1",
                Email = "Test1@mail.com",
                PhoneNo = "11223344",
            });
            context.Trainer.Add(new Trainer()
            {
                FirstName = "Test First Name 2",
                LastName = "Test Last Name 2",
                Email = "Test2@mail.com",
                PhoneNo = "99887766",
            });

            //News
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "ghdfjkln,mfnfdhjkfglmdf dgfhjkdsnbfdjkg ",
                Picture = "/Content/Pictures/oprydning.jpg",
                Date = new DateTime(2015, 12, 01)

            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "ghjkmnbghjkmnbhjk  djkfl,dm",
                Picture = "/Content/Pictures/maskine.jpg",
                Date = new DateTime(2015, 12, 02)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "vfgdhjfnkdfmlgvd dhfjdbsfjk",
                Picture = "/Content/Pictures/oprydning_2.jpg",
                Date = new DateTime(2015, 12, 03)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "djfbdskfndslkfshj",
                Picture = "/Content/Pictures/maskine2.jpg",
                Date = new DateTime(2015, 12, 04)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "kdfdk njffkgn",
                Picture = "/Content/Pictures/maskine.jpg",
                Date = new DateTime(2015, 12, 05)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "lkgmgdsjkbfdjkggfg dffgg",
                Picture = "/Content/Pictures/oprydning_2.jpg",
                Date = new DateTime(2015, 12, 06)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "sdasdadada",
                Picture = "/Content/Pictures/oprydning_2.jpg",
                Date = new DateTime(2015, 12, 07)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "874854165fdgdfg",
                Picture = "/Content/Pictures/oprydning.jpg",
                Date = new DateTime(2015, 12, 08)
            });
            context.News.Add(new News()
            {
                Title = "Lorem Ipsum",
                Description = "dsflndsf8fgdsg",
                Picture = "/Content/Pictures/maskine.jpg",
                Date = new DateTime(2015, 12, 09)
            });

            //Events
            context.Event.Add(new Event()
            {
                Description = "sdjfsdlksdfmf",
                Title = "Event title",
                Date = new DateTime(2015, 12, 05)
            });

            context.Event.Add(new Event()
            {
                Description = "sdfsdfsgg33434",
                Title = "Another event",
                Date = new DateTime(2015, 12, 13)
            });
            context.Event.Add(new Event()
            {
                Description = "Happy birthday baby Jeebus",
                Title = "Christmas Event! ",
                Date = new DateTime(2015, 12, 24)
            });
            context.Event.Add(new Event()
            {
                Description = "8f5gdfg",
                Title = "Just another event...",
                Date = new DateTime(2015, 12, 11)
            });
            base.Seed(context);
        }
    }
}
