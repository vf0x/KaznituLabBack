using System;
using System.Collections.Generic;

#nullable disable

namespace EFData.HrEntity
{
    public partial class EmployeeDetail
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstNameTranslit { get; set; }
        public string MiddleNameTranslit { get; set; }
        public string LastNameTranslit { get; set; }
        public string PersonalCardNumber { get; set; }
        public string PersonalCardIssuer { get; set; }
        public DateTime? PersonalCardIssueDate { get; set; }
        public int? PlaceOfBirthId { get; set; }
        public string PlaceOfBirth { get; set; }
        public int? NationalityId { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsFaculty { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? CitizenshipId { get; set; }
        public bool? IsForeigner { get; set; }
        public DateTime? ForeignerTermStartDate { get; set; }
        public DateTime? ForeignerTermEndDate { get; set; }
        public int? ForeignerTermDays { get; set; }
        public int? EducationId { get; set; }
        public int? EducationLanguageId { get; set; }
        public bool? TeachingInEnglish { get; set; }
        public bool? PublishedScientificArticles { get; set; }
        public int? PublishedScientificArticleIndustryId { get; set; }
        public int? PublishedScientificArticlesNumber { get; set; }
        public int? EnglishLevelId { get; set; }
        public bool? IsFinancialResponsible { get; set; }
        public bool? IsAup { get; set; }
        public bool? IsPp { get; set; }
        public bool? IsUvp { get; set; }
        public bool? IsOp { get; set; }

        public virtual SimpleDictionary Citizenship { get; set; }
        public virtual SimpleDictionary Education { get; set; }
        public virtual SimpleDictionary EducationLanguage { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SimpleDictionary EnglishLevel { get; set; }
        public virtual SimpleDictionary MaritalStatus { get; set; }
        public virtual SimpleDictionary Nationality { get; set; }
        public virtual SimpleDictionary PlaceOfBirthNavigation { get; set; }
        public virtual SimpleDictionary PublishedScientificArticleIndustry { get; set; }
    }
}
