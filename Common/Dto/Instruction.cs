using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Dto
{
    public class Instruction
    {
        //public int RecipeId { get; set; }
        public int InstructionId { get; set; }
        public int StepNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
