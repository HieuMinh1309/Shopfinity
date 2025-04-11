using System;
using System.Collections.Generic;

namespace SSE_Project.Models;

public partial class ChatRoom
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? EmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime LastActivity { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual Order Order { get; set; } = null!;
}
