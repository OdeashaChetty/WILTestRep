using System;
using System.Collections.Generic;

namespace WILTestDesignSpace.Models;

public partial class Category
{
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
