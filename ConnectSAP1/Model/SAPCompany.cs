namespace ConnectSAP1.Model
{
    public class SAPCompany
    {
        public string SQLUSER { get; set; }
        public string SQLPASSWORD { get; set; }
        public string SAPSERVER { get; set; }
        public string SAPDB { get; set; }
        public string? SAPUSER { get; set; }
        public string? SAPPASSWORD { get; set; }
        //public string? SQLVERSION { get; set; }
        public string? SLDSERVER { get; set; }
        public string? SAPLiSCENSE { get; set; }
        public bool UseTrusted { get; set; } = false;
    }
}
