using System.ComponentModel.DataAnnotations;

namespace Discoteque.Data.Models;

public class Artist : BaseEntity<int>
{
    /// <summary>
    /// The Name of the Artist
    /// </summary>
    /// <value></value>
    [StringLength(100, ErrorMessage = "The artist name can't exceed 100 characters")]
    public string Name { get; set; } = "";
    public string Label { get; set; } = "";
    public bool IsOnTour{ get; set; }
}