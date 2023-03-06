namespace BrokrService.Models
{
    public class ResponseModel
    {
            
        public bool IsSucceed { get; set; }
        public string PolicyID { get; set; }
        public string PolicyUniqueID { get; set; }
        public List<DataGroup> DataGroup { get; set; }
        public List<string> ErrCodes { get; set; }
        public List<string> ErrMsgs { get; set; }
        public List<string> WarnCodes { get; set; }
        public List<string> WarnMsgs { get; set; }
    }


    public class DataGroup
    {
        public string GroupName { get; set; }
        public int GroupTag { get; set; }
        public int GroupCount { get; set; }
        public List<Attribute> AttArray { get; set; }
    }

    public class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

}
    

