using System;
using System.Collections.Generic;

namespace WebApplication1.UniversityModels;

public partial class Message
{
    public int MessageId { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string? MessageText { get; set; }

    public DateTime? SentDate { get; set; }

    public string? SenderType { get; set; }

    public string? ReceiverType { get; set; }
}
