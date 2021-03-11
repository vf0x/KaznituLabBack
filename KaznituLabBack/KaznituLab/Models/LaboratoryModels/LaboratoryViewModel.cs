using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaznituLab.Models.EquipmentModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KaznituLab.Models.Laboratory
{
    public class LaboratoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FieldOfStudy { get; set; }
        public string Accreditation { get; set; }
        public string PositionLaboratory { get; set; }
        public string LaboratoryPhotoName { get; set; }
        public string Address { get; set; }
        public string Office { get; set; }
        public string LocationPhotoName { get; set; }
    }
    public class LaboratoryGetAllResponseModel : LaboratoryViewModel
    {
        public DictionaryModel Department { get; set; }
        public DictionaryModel Status { get; set; }
        public DictionaryModel DirectorEmployee { get; set; }
    }
    public class LaboratoryGetResponseModel : LaboratoryGetAllResponseModel
    {
        public IEnumerable<AdvanceDictionaryModel> Employees { get; set; }
        public IEnumerable<EquipmentViewModel> Eqiupments { get; set; }
        public IEnumerable<DictionaryModel> Services { get; set; }
        public IEnumerable<DictionaryModel> Projects { get; set; }
    }
    public class LaboratoryGetRequesetModel
    {
        public string Data { get; set; }
        public IFormFile LabPhotoFileData { get; set; }
        public IFormFile LocationPhotoFileData { get; set; }
        public LaboratoryDataRequesetModel GetLaboratory()
        {
            return JsonConvert.DeserializeObject<LaboratoryDataRequesetModel>(Data);
        }
    }
    public class LaboratoryRemovedModel : LaboratoryViewModel
    {
        public List<int?> EmployeeRemovedIds { get; set; }
        public List<int?> EqiupmentRemovedIds { get; set; }
        public List<int?> ServiceRemovedIds { get; set; }
    }
    public class LaboratoryDataRequesetModel : LaboratoryRemovedModel
    {
        public int DepartmentId { get; set; }
        public int? StatusId { get; set; }
        public int? DirectorEmployeeId { get; set; }
        public List<int> EmployeeIds { get; set; }
        public List<int> EqiupmentIds { get; set; }
        public List<int> ProjectIds { get; set; }
        public IEnumerable<DictionaryModel> Services { get; set; }

    }

}
