﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{ //Id,CarId,ImagePath,Date
    public class CarImage: IEntity
    {

        [Key] public int ImageId { get; set; } 
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Date { get; set; }

    }
}
