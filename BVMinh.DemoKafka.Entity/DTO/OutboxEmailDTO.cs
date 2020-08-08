using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Entity.DTO
{
    [Serializable]
    public class OutboxEmailDTO
    {
        public string EmailID { get; set; }
        public string ApplicationCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailSenderName { get; set; }
        public string EmailSenderAddress { get; set; }
        public int RetryTime { get; set; }
        public List<RecipientDTO> Recipients { get; set; }
    }
}
