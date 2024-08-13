using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace VSGComputers.Models
{
    public class Computer
    {
        public Computer()
        {
            
        }
        public Computer(int id, string processor, string videoCard, int memory, int storage, string motherBoard, string @case,string imageUrl)
        {
            Id = id;
            Processor = processor;
            VideoCard = videoCard;
            Memory = memory;
            Storage = storage;
            MotherBoard = motherBoard;
            Case = @case;
            ImageURL = imageUrl;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Length(1, 20,ErrorMessage = "Length should be in the range between 1 and 20")]
        public string MotherBoard { get; set; }

        [Required]
        [Length(1, 20,ErrorMessage = "Length should be in the range between 1 and 20")]
        public string Processor { get; set; }

        [Required]
        [Length(1, 20, ErrorMessage = "Length should be in the range between 1 and 20")]
        public string VideoCard { get; set; }

        [Required]
        [DisplayName("RAM")]
        [Range(1, 512, ErrorMessage = "RAM should be in the range between 1 and 512")]
        public int Memory { get; set; }

        [Required]
        [DisplayName("SSD")]
        [Range(100, 10000, ErrorMessage = "SSD should be in the range between 100 and 10000")]
        public int Storage { get; set; }

        [Required]
        [Length(1, 20, ErrorMessage = "Length should be in the range between 1 and 20")]
        public string Case { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }
    }
}
