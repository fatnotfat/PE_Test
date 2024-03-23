﻿using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string CategoryDescription { get; set; } = null!;

    public string? FromCountry { get; set; }

    public virtual ICollection<SilverJewelry> SilverJewelries { get; } = new List<SilverJewelry>();
}
