﻿namespace Application.Commons.Dtos;

public record GetLibResponse
{
    public GetLibDto Data { get; set; } = new GetLibDto();
}

public record GetAllLibResponse
{
    public List<GetLibDto> Data { get; set; } = new List<GetLibDto>();
}

public record GetLibDto
{
    public int Id { get; set; }
    public string Value { get; set; }
}