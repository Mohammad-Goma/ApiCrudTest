using System.ComponentModel.DataAnnotations;

namespace RestFullApiFirstProject.Data
{
    public class GenreDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
