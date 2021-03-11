using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KaznituLab.Models.WorkModels
{
    public class WorkViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public WorkAuthorModel Author { get; set; }
        public string SourceTitle { get; set; }
        public int ReleaseYear { get; set; }
        public string Doi { get; set; }
        public string Issn { get; set; }
        public string Essn { get; set; }
        public string Isbn { get; set; }
        public bool PublishedMonRK { get; set; }
    }
    public class WorkGetAllResponseModel : WorkViewModel
    {
        public DictionaryModel WorkType { get; set; }
    }
    public class WorkGetResponseModel : WorkGetAllResponseModel
    {
        public IEnumerable<WorkCoAuthorModel> CoAuthors { get; set; }
    }
    public class WorkRequestModel
    {
        public string Data { get; set; }
        public WorkGetResponseModel GetWorkData()
        {
            return JsonConvert.DeserializeObject<WorkGetResponseModel>(Data);
        }
    }
}
