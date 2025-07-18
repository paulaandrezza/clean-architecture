﻿using Domain.Common;

namespace Domain.Aggregates.UserAggregate;

public class Phone : BaseEntity, IEntity
{
    public string? PhoneNumber { get; set; }
    public bool IsWhatsApp { get; set; } = false;
}
