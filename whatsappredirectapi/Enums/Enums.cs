using System.ComponentModel;

namespace whatsappredirectapi.Enums
{
    public class Enums
    {
        public enum ChannelEnums
        {
            [Description("Whatsapp")]
            WhatsApp = 1,

            [Description("Instagram")]
            Instagram = 2,

            [Description("Facebook")]
            Messenger = 3,

            [Description("Twitter")]
            X = 4,

            [Description("Telegram")]
            Telegram = 5,

            [Description("Mail")]
            Mail = 6,

            [Description("WebForm & WebForm API")]
            WebForm = 7,

            //[Description("WebForm API")]
            //WebFormAPI = 8,

            [Description("Live Chat")]
            LiveChat = 9,

            [Description("Google Business Messages")]
            GoogleBusinessMessages = 10,

            [Description("Other")]
            Other = 11
        }

        public enum LatestMessageOwnerEnums
        {
            Agent = 1,
            Lead = 2,
        }
        public enum LeadHistoryTypeEnums
        {
            [Description("Created")]
            Created = 1,

            [Description("Assigned")]
            Assigned = 2,

            [Description("Reassigned")]
            Reassigned = 3,

            [Description("Status Changed")]
            StatusChanged = 4,

            [Description("Tag Changed")]
            TagChanged = 5,

            [Description("Contact Information Updated")]
            ContactInformationUpdated = 6,

            [Description("Note Added")]
            NoteAdded = 7,

            [Description("Product Added")]
            ProductAdded = 8,

            [Description("Product Removed")]
            ProductRemoved = 9,

            [Description("Consultation Added")]
            ConsultationAdded = 10,

            [Description("Consultation Removed")]
            ConsultationRemoved = 11,

            [Description("Offer Sent")]
            OfferSent = 12,

            [Description("Sold")]
            Sold = 13,

            [Description("Lost")]
            Lost = 14,

            [Description("Reminder Added")]
            ReminderAdded = 15,

            [Description("Reminder Removed")]
            ReminderRemoved = 16,

            [Description("Deposit Details Added")]
            DepositDetailsAdded = 17,

            [Description("Deposit Details Updated")]
            DepositDetailsUpdated = 18,

            [Description("Logistic Details Added")]
            LogisticDetailsAdded = 19,

            [Description("Logistic Details Updated")]
            LogisticDetailsUpdated = 20,

            [Description("Calender Event Planned")]
            CalenderEventPlanned = 21,

            [Description("Media Added")]
            MediaAdded = 22,

            [Description("Lead Merged")]
            LeadMerged = 23,

            [Description("Treatment Completed")]
            TreatmentCompleted = 24,
        }
    }
}
