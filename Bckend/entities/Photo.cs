using System.ComponentModel.DataAnnotations.Schema;

namespace Bckend.entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string URL { get; set; }
    public bool isMainPhoto { get; set; }
    public string? photoId  { get; set; }
    public int AppuserId { get; set; }
    public Appuser Appuser { get; set; } = null!;
}