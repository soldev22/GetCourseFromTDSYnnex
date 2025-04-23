using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetCourseFromTDSYnnex
{
    public class EduDexCourse
    {
        public ClientId clientId { get; set; }
        public string editor { get; set; }
        public string expires { get; set; }
        public string format { get; set; }
        public string generator { get; set; }
        public string lastEdited { get; set; }
        public ProgramAdmission programAdmission { get; set; }
        public ProgramClassification programClassification { get; set; }
        public ProgramDescriptions programDescriptions { get; set; }
        public ProgramContacts programContacts { get; set; }
        public ProgramCurriculum programCurriculum { get; set; }
        public ProgramSchedule programSchedule { get; set; }
    }

    public class ClientId
    {
        public string orgUnitId { get; set; }
    }

    public class ProgramAdmission
    {
        public bool applicationOpen { get; set; }
        public string applicationType { get; set; }
        public string paymentDue { get; set; }
        public string startDateDetermination { get; set; }
    }

    public class ProgramClassification
    {
        public string degree { get; set; }
        public string orgUnitId { get; set; }
        public ProgramDuration programDuration { get; set; }
        public List<string> programForm { get; set; }
        public string programId { get; set; }
        public string programLevel { get; set; }
        public List<ProgramLocation> programLocation { get; set; }
        public string programType { get; set; }
        public List<int> salaryScaleBBRA { get; set; }
    }

    public class ProgramDuration
    {
        public int days { get; set; }
    }

    public class ProgramLocation
    {
        public string description { get; set; }
        public string id { get; set; }
    }

    public class ProgramDescriptions
    {
        public LanguageContent programDescriptionText { get; set; }
        public LanguageContent programName { get; set; }
        public LanguageContent programSummaryText { get; set; }
        public LanguageContent courseSiteLink { get; set; }
    }

    public class LanguageContent
    {
        public string nl { get; set; }
    }

    public class ProgramContacts
    {
     
    }

    public class ProgramCurriculum
    {
        // Expand with fields if needed
    }

    public class ProgramSchedule
    {

    }

}
