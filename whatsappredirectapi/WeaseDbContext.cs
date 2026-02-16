using Microsoft.EntityFrameworkCore;
using whatsappredirectapi.Models;

namespace whatsappredirectapi
{
    public class WeaseDbContext : DbContext
    {
        public WeaseDbContext(DbContextOptions<WeaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<LeadConversation> LeadConversations { get; set; }
        public DbSet<CxWhatsappMessage> CxWhatsappMessages { get; set; }
        public DbSet<LeadLatestMessage> LeadLatestMessages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LeadHistory> LeadHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>().ToTable("leads", "wease");
            modelBuilder.Entity <Channel>().ToTable("channels", "common");
            modelBuilder.Entity<LeadConversation>().ToTable("lead_conversations", "wease");
            modelBuilder.Entity<CxWhatsappMessage>().ToTable("cx_whatsapp_messages", "wease");
            modelBuilder.Entity<LeadLatestMessage>().ToTable("lead_latest_messages", "wease");
            modelBuilder.Entity<Address>().ToTable("addresses", "common");
            modelBuilder.Entity<LeadHistory>().ToTable("lead_histories", "wease");
        }
    }
}
