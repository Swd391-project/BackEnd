﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWD.BBMS.Services.BusinessModels
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Role { get; set; }

        public string? Image {  get; set; }

        public UserModelStatus Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public int? CompanyId { get; set; }

        public CompanyModel? Company { get; set; }

        public List<FeedbackModel>? Feedbacks { get; set; }
    }
}
