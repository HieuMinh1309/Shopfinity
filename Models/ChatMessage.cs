using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ChatMessage
{
    public long Id { get; set; }

    public int ChatroomId { get; set; }

    public int? EmployeeId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string SenderType { get; set; } = null!;

    public bool IsRead { get; set; }

    public virtual ChatRoom Chatroom { get; set; } = null!;
}
