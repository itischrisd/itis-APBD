﻿namespace KolokwiumCF.DTOs.Response;

public class ClientDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public double Discount { get; set; }
    public List<SubscriptionDTO> Subscriptions { get; set; } = null!;
}