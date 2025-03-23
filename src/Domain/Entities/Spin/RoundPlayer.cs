﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Spin;

public class RoundPlayer
{
    [Key]
    public int Id { get; set; }

    public int PlayerId { get; set; }
    public int RoundId { get; set; }
    public bool Host { get; set; }
}