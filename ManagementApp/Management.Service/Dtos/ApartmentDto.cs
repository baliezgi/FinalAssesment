﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Service.Dtos
{
    public class ApartmentDto
    {
        public Guid Id { get; set; }
        public int BlokNo { get; set; }
        public int Floor { get; set; }
        public int DoorNo { get; set; }

    }
}
