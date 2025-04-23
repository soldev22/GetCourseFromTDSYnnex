using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCourseFromTDSYnnex
{
    public class Course
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? RegistrationLink { get; set; }
        public string? Category { get; set; }
        public string? Vendor { get; set; }
        public string? ClassroomDeliveryMethod { get; set; }
        public Dictionary<string, CourseDescription> Descriptions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public double? Duration { get; set; }
        public string DurationUnit { get; set; }
        public string IbmIPType { get; set; }
        public decimal? ListPrice { get; set; }
        public string Currency { get; set; }
        public string Badge_Template_ID { get; set; }
        public string Badge_Title { get; set; }
        public string Badge_Url { get; set; }
    }

    public class CourseDescription
    {
        public string Description { get; set; }
        public string Overview { get; set; }
        public string Abstract { get; set; }
        public string Prerequisits { get; set; }
        public string Objective { get; set; }
        public string Topic { get; set; }
    }

}
