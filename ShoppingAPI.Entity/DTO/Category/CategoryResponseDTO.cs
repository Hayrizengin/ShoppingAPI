﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.DTO.Category
{
    public class CategoryResponseDTO:CategoryDTOBase
    {
        public Guid Guid { get; set; }
    }
}