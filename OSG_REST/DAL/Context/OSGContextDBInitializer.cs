﻿using System;
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
        private string description =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam in enim massa. Sed vestibulum vel ante quis elementum. Nam sollicitudin justo ac urna malesuada, in dictum enim ultrices. Suspendisse odio lorem, malesuada et enim id, congue rhoncus neque. Praesent pulvinar nibh pretium dolor laoreet, a eleifend nibh mollis. Quisque auctor purus eu nisl tincidunt, vitae tincidunt eros ullamcorper. Aliquam erat volutpat. Fusce diam eros, pulvinar id rhoncus nec, lobortis eget leo. Nullam tristique ipsum sit amet congue pulvinar. Maecenas fermentum, felis vitae pharetra elementum, risus risus porttitor sem, nec porta sapien mauris vitae sem. Fusce quis purus ligula. Maecenas rutrum porta fermentum. Sed ligula metus, tincidunt ac est ut, imperdiet egestas ante. Nullam nec ligula pulvinar, convallis quam ut, finibus lorem";
        protected override void Seed(OSGContext context)
        {
            //Trainers
            context.Trainer.Add(new Trainer()
            {
                Id = 1,
                FirstName = "Mikkel",
                LastName = "Madsen",
                Email = "mikkel@mail.com",
                PhoneNo = "22334455",
            });

            context.Trainer.Add(new Trainer()
            {
                Id = 1,
                FirstName = "Test First Name 1",
                LastName = "Test Last Name 1",
                Email = "Test1@mail.com",
                PhoneNo = "11223344",
            });

            context.Trainer.Add(new Trainer()
            {
                Id = 1,
                FirstName = "Test First Name 2",
                LastName = "Test Last Name 2",
                Email = "Test2@mail.com",
                PhoneNo = "99887766",
            });

            //News
            context.News.Add(new News()
            {
                Id = 1,
                Title = "Lorem Ipsum",
                Date = DateTime.Today,
                Description = description,
            });

            base.Seed(context);
        }
    }
}
