using Microsoft.EntityFrameworkCore;
using TracePointAPI.Models;

namespace TracePointAPI.Data
{
    public class TracePointDbContext : DbContext
    {
        public TracePointDbContext(DbContextOptions<TracePointDbContext> options)
            : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Suspect> Suspects { get; set; }

        public DbSet<Evidence> Evidence { get; set; }

        public DbSet<Investigation> Investigations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Case
            modelBuilder.Entity<Case>().HasData(
                new Case
                {
                    CaseID = 1,
                    CaseName = "The Missing Prototype",
                    Description = "A prototype has disappeared from a secure research laboratory.",
                    Status = "OPEN"
                }
            );

            // Suspects
            modelBuilder.Entity<Suspect>().HasData(
                new Suspect
                {
                    SuspectID = 1,
                    Name = "Alex Morgan",
                    Occupation = "Software Developer",
                    Description = "Alex developed the software used by the prototype and had access to the laboratory."
                },

                new Suspect
                {
                    SuspectID = 2,
                    Name = "Jamie Smith",
                    Occupation = "Security Officer",
                    Description = "Jamie was responsible for security at the building on the night of the incident."
                },

                new Suspect
                {
                    SuspectID = 3,
                    Name = "Taylor Williams",
                    Occupation = "Research Assistant",
                    Description = "Taylor worked with the research team and had access to the laboratory during working hours."
                }
            );

            // Evidence
            modelBuilder.Entity<Evidence>().HasData(
                new Evidence
                {
                    EvidenceID = 1,
                    Title = "Security Access Log",
                    Description = "Jamie Smith's access card was used to enter the research laboratory at 23:41.",
                    Location = "Security Office"
                },

                new Evidence
                {
                    EvidenceID = 2,
                    Title = "CCTV Report",
                    Description = "CCTV footage shows a person entering the laboratory at approximately 23:43. The person's face cannot be clearly identified.",
                    Location = "Research Laboratory"
                },

                new Evidence
                {
                    EvidenceID = 3,
                    Title = "Fingerprint Report",
                    Description = "A partial fingerprint was found on the prototype storage cabinet.",
                    Location = "Research Laboratory"
                },

                new Evidence
                {
                    EvidenceID = 4,
                    Title = "Email Message",
                    Description = "An email sent shortly before the incident states that the prototype must be moved before tomorrow's demonstration.",
                    Location = "Archive Room"
                },

                new Evidence
                {
                    EvidenceID = 5,
                    Title = "Photograph",
                    Description = "A photograph taken after the incident shows that the prototype cabinet was open and the laboratory lights were switched off.",
                    Location = "Research Laboratory"
                }
            );
        }
    }
}