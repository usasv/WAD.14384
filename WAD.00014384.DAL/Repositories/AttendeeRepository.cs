﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._00014384.DAL.Data;
using WAD._00014384.DAL.Interfaces;
using WAD._00014384.DAL.Models;

namespace WAD._00014384.DAL.Repositories
{
    public class AttendeeRepository : BaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
