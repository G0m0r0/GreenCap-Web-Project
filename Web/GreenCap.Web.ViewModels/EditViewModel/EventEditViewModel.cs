﻿namespace GreenCap.Web.ViewModels.EditViewModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;
    using GreenCap.Data.Models;
    using GreenCap.Services.Mapping;

    public class EventEditViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataValidation.NameTitleMinLength)]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        [Display(Name = "Event name")]
        public string Name { get; set; }

        [Required]
        [MinLength(DataValidation.Events.DescriptionMinLength)]
        [MaxLength(DataValidation.Events.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidation.UrlPathMaxLength)]
        public string ImagePath { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(DataValidation.Events.TotalPeopleMinCount, DataValidation.Events.TotalPeopleMaxCount)]
        [Display(Name = "Total people")]
        public int TotalPeople { get; set; }
    }
}
