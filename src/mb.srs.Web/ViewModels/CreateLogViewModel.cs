using mb.srs.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace mb.srs.Web.ViewModels
{
    public class CreateLogViewModel
    {
        [Required]
        public string Name { get; set; } = "Mohammed Babiker";

        [Required]
        public string Type { get; set; }
        
        [Required]
        public DateTime IncidentDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ReportedDate { get; set; } = DateTime.Now;
        
        [Required]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Required]
        public string DepartmentId {  get; set; }   

        [Required]
        public string Manager { get; set; }
        
        [Required]
        public string JobTitle {  get; set; } = "Production Associate";

        [Required]
        public Tested? Tested { get; set; }

        [Required]
        public Circumstances Circumstances { get; set; }

        [Required]
        public bool FullyVaccinated { get; set; }

        [Required]
        public DateTime? FirstDose { get; set; } = null;

        [Required]
        public DateTime? SecondDose { get; set; } = null;
    }

    public enum Tested { yes, no, pending, not_tested }
    public enum Circumstances { symptomatic, contact_at_work, contact_away_from_work, vaccinated }

}
