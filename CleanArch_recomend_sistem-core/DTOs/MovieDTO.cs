﻿
namespace CleanArch_recomend_sistem.Core.DTOs;

public class MovieDTO
{
    public Id Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }

    public static implicit operator MovieDTO(Movie other) =>
        new()
        {
            Id = other.Id,
            Title = other.Title,
            Genre = other.Genre,
            Rating = other.Rating,
        };
}
