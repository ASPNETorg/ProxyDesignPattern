namespace SinglePage.Sample01.ApplicationServices.Dtos.PersonDtos;

public class GetPersonServiceDto
{
    public Guid? Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }
}