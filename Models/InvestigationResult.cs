namespace TracePointAPI.Models
{
    public class InvestigationResult
    {
        public int InvestigationID { get; set; }
        public string SuspectName { get; set; }
        public string Conclusion { get; set; }
        public DateTime DateStarted { get; set; }
    }
}
