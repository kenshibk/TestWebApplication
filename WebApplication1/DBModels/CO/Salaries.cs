﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DBModels.CO;

public partial class Salaries
{
    [Key]
    public int EmployeeID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public DateOnly EffectiveDate { get; set; }

    [ForeignKey("EmployeeID")]
    [InverseProperty("Salaries")]
    public virtual Employees Employee { get; set; }
}