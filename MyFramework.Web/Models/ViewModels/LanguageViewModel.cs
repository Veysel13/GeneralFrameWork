﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFramework.Web.Models.ViewModels
{
    [Table("Languages")]
    [DisplayColumn("LanguageName")]
    [DisplayName("Language")]
    public class LanguageViewModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "LanguageId Id", AutoGenerateField = false)]
        public virtual int LanguageId { get; set; }
        [Display(Name = "Name"), Required()]
        public virtual string Name { get; set; }
        [Display(Name = "Code"), Required()]
        public virtual string Code { get; set; }

    }
}